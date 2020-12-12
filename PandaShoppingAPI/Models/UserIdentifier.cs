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
        public List<string> RoleNames { get; set; }

        public UserIdentifier(int userId, List<string> roleNames)
        {
            UserId = userId;
            RoleNames = roleNames;
        }
    }
}
