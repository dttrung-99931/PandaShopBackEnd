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
        public string RoleName { get; set; }
        public string Username { get; set; }
        public int AccountId { get; set; }

        public UserIdentifier(int userId, string roleName, 
            string username, int accountId)
        {
            this.UserId = userId;
            this.RoleName = roleName;
            this.Username = username;
            this.AccountId = accountId;
        }

    }
}
