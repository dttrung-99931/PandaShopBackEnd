using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using PandaShoppingAPI.Utils.ServiceUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class UserResponseModel : BaseModel<User_, UserResponseModel>
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        //public string password { get; set; }
        public int cartId { get; set; }
        public ShopResponseModel shop { get; set; }

        // TODO: Disable mapping shop when it's null
        // Below not working
        //protected override void CustomMapping(IMappingExpression<User_, UserResponseModel> mappingExpression, IConfiguration config)
        //{
        //    mappingExpression
        //        .ForAllMembers(
        //        (opts) => opts.Condition((src, dest, srcMember) => srcMember != null)  
        //        );
        //}

    }
}
