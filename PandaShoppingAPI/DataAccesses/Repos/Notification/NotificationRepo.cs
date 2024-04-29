using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class NotificationRepo : BaseRepo<Notification>, INotificationRepo
    {
        public NotificationRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
