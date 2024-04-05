using AutoMapper;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using PandaShoppingAPI.Utils.ServiceUtils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class WarehouseService: BaseService<IWarehouseRepo, Warehouse, WarehouseModel, Filter>, IWarehouseService
    {
        private readonly IUserRepo _userRepo;
        public WarehouseService(IWarehouseRepo repo, IUserRepo userRepo) : base(repo)
        {
            _userRepo = userRepo;
        }

        protected override Warehouse MapInsertEntity(WarehouseModel requestModel)
        {
            Warehouse warehouse = base.MapInsertEntity(requestModel);
            warehouse.shopId = _userRepo.GetById(User.UserId).shopId.Value;
            return warehouse;
        }

        protected override void ValidateInsert(WarehouseModel requestModel)
        {
            if (_userRepo.GetById(User.UserId)?.shopId == null)
            {
                throw new ConflictException(ErrorCode.unregisterdShop);
            }
        }
    }
}
