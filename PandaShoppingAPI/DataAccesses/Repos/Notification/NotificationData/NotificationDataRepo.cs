using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class NotificationDataRepo : BaseRepo<NotificationData>, INotificationDataRepo
    {
        public NotificationDataRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
