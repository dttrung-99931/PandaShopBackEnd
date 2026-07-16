using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class LoginModel : BaseModel<User_, UserModel>
    {
        /// <summary>
        /// Username
        /// </summary>
        /// <example>0988202071</example>
        public string username { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        /// <example>aa123456</example>
        public string password { get; set; }
    }
}
