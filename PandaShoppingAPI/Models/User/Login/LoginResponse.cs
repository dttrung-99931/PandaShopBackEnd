using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class LoginResponse
    {
        public int userID { get; set; }
        public string token { get; set; }
        public int cartId { get; set; }
        public DateTime expires { get; set; }
        public ShopResponseModel shop { get; set; }
        public LoginResponse()
        {
        }

        public LoginResponse(int userID, string token, DateTime expires, int cartId, ShopResponseModel shop)
        {
            this.userID = userID;
            this.token = token;
            this.expires = expires;
            this.cartId = cartId;
            this.shop = shop;
        }
    }
}
