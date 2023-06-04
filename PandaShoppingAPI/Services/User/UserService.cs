using AutoMapper;
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
        private readonly IConfiguration _config;

        public UserService(
            IUserRepo repo,
            IShopRepo shopRepo,
            IConfiguration config) : base(repo)
        {
            _shopRepo = shopRepo;
            _config = config;
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
                throw new ConflictException();
            }
            
            var shopId = _shopRepo.Insert(Mapper.Map<Shop>(shopModel)).id;
            user.shopId = shopId;
            
            _repo.Update(user, user.id);
        }

        public LoginResponse Login(LoginModel loginModel)
        {
            var user = _repo.Where(u => u.phone == loginModel.phone)
                .FirstOrDefault();

            if (user != null && user.password == loginModel.password)
            {
                return CreateLoginResponse(user);
            }
            else return null;
        }

        private LoginResponse CreateLoginResponse(User_ user)
        {
            var claims = new List<Claim>()
            {
                new Claim(Constants.CLAIM_USER_ID, user.id.ToString()),
                new Claim(Constants.CLAIM_CART_ID, user.cartId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.phone)
            };

            var roleClaims = GetRoleClaims(user.UserRole.ToList());

            claims.AddRange(roleClaims);

            var expires = ComputeExpiredDateByRoles(user.UserRole.ToList());

            var token = GenerateToken(claims.ToArray(), expires);

            return new LoginResponse(user.id, token, expires, user.cartId);
        }

        private DateTime ComputeExpiredDateByRoles(List<UserRole> userRoles)
        {
            var expires = DateTime.Now;

            foreach (var userRole in userRoles)
            {
                var roleName = userRole.role.name;
                if (roleName == "admin")
                    return expires.AddDays(5);

                if (roleName == "shop")
                    return expires.AddDays(10);

                if (roleName == "user")
                    return expires.AddDays(10);
            }

            throw new Exception("Undefined role: " + userRoles);
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
                ur => roleClaims.Add(new Claim(ClaimTypes.Role, ur.role.name))
            );
            return roleClaims;
        }

        public int GetCartIdOfUser(int userId)
        {
            return GetById(userId).cartId;
        }

    }
}
