using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class UserService : BaseService<IUserRepo, User_, UserModel, UserFilter>,
        IUserService
    {
        private readonly IShopRepo _shopRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly IConfiguration _config;

        public UserService(
            IUserRepo repo,
            IShopRepo shopRepo,
            IRoleRepo roleRepo,
            IConfiguration config) : base(repo)
        {
            _shopRepo = shopRepo;
            _roleRepo = roleRepo;
            _config = config;
        }

        protected override void ValidateInsert(UserModel requestModel)
        {
            if (_repo.Any((user) => user.phone == requestModel.phone))
            {
                throw new ConflictException(ErrorCode.userExisted);
            }
        }

        protected override User_ MapInsertEntity(UserModel requestModel)
        {
            User_ insertUsr = base.MapInsertEntity(requestModel);
            // Currently all created users will be user 
            // TODO: created user with role param
            insertUsr.UserRole.Add(new UserRole { roleId = (int)Roles.user });
            insertUsr.Receivers.Add(new NotificationReceiver { signalRToken = "Default", senderType = NotificationSenderType.SignalR, });
            return insertUsr;
        }


        public void InsertShop(int userId, ShopModel shopModel)
        {
            var user = GetById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException();
            }
            if (user.shopId != null)
            {
                throw new ConflictException(ErrorCode.shopExisted);
            }

            var shopId = _shopRepo.Insert(Mapper.Map<Shop>(shopModel)).id;
            user.shopId = shopId;
            user.UserRole.Add(
                new UserRole()
                {
                    roleId = (int) Roles.shop
                }
            );
            _repo.Update(user, user.id);
        }

        public LoginResponse Login(LoginModel loginModel)
        {
            var user = _repo.Where(u => u.phone == loginModel.phone)
                .Include(u => u.UserRole)
                .ThenInclude(ur => ur.role)
                .FirstOrDefault();

            if (user != null && user.password == loginModel.password)
            {
                return CreateSuccessLoginResponse(user);
            }

            return null;
        }

        private LoginResponse CreateSuccessLoginResponse(User_ user)
        {
            var claims = new List<Claim>()
            {
                new Claim(Constants.CLAIM_USER_ID, user.id.ToString()),
                new Claim(Constants.CLAIM_CART_ID, user.cartId.ToString()),
                new Claim(Constants.CLAIM_SHOP_ID, user.shopId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.phone)
            };

            List<UserRole> userRoles = user.UserRole.ToList();
            var roleClaims = GetRoleClaims(userRoles);

            claims.AddRange(roleClaims);

            var expires = ComputeExpiredDateByRoles(userRoles);

            var token = GenerateToken(claims.ToArray(), expires);

            return new LoginResponse(
                user.id,
                token,
                expires,
                user.cartId,
                user.shopId != null ? Mapper.Map<ShopResponseModel>(user.shop) : null);
        }

        private DateTime ComputeExpiredDateByRoles(List<UserRole> userRoles)
        {
            var expires = DateTime.Now;

            foreach (var userRole in userRoles)
            {
                if (userRole.roleId == (int)Roles.admin)
                    return expires.AddDays(5);

                if (userRole.roleId == (int)Roles.shop)
                    return expires.AddDays(10);

                if (userRole.roleId == (int)Roles.user)
                    return expires.AddDays(10);
            }

            throw new Exception("Undefined role: " + userRoles.ToString());
        }

        private string GenerateToken(Claim[] claims, DateTime expires)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken
                (
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Issuer"],
                    claims: claims,
                    expires: expires,
                    signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }


        private List<Claim> GetRoleClaims(List<UserRole> userRoles)
        {
            var roleClaims = new List<Claim>();
            userRoles.ForEach(
                ur => roleClaims.Add(new Claim(ClaimTypes.Role, ur.role.name.Trim()))
            );
            return roleClaims;
        }

        public int GetCartIdOfUser(int userId)
        {
            return GetById(userId).cartId;
        }

        public override IQueryable<User_> Fill(UserFilter filter)
        {
            // TODO: prevent get other shop
            return base.Fill(filter);
        }
    }
}
