using PandaShoppingAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{

    // Used to: Store userId (is curtomerId or garageId...), RoleName, Username
    //          Determine if User is admin or customer or garage or org
    public class UserIdentifier
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
        public int ShopId { get; set; }
        public int DriverId { get; set; }
        public List<string> RoleNames { get; set; }

        public UserIdentifier(
            int userId,
            int cartId,
            int shopId,
            List<string> roleNames,
            int driverId
         )
        {
            UserId = userId;
            CartId = cartId;
            ShopId = shopId;
            RoleNames = roleNames;
            DriverId = driverId;
        }

        public bool IsShop
        {
            get
            {
                return RoleNames.Contains("shop");
            }
        }

        public bool IsAdmin
        {
            get
            {
                return RoleNames.Contains("admin");
            }
        }

        public bool IsUser
        {
            get
            {
                return RoleNames.Contains("user");
            }
        }

    }
}
