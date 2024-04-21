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
    public class UserShortResponseModel : BaseModel<User_, UserShortResponseModel>
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
