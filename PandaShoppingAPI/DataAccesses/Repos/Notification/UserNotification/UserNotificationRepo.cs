using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class UserNotificationRepo : BaseRepo<UserNotification>, IUserNotificationRepo
    {
        public UserNotificationRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
