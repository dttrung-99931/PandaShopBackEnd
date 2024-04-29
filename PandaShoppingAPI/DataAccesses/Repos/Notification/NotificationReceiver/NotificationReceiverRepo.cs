using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class NotificationReceiverRepo : BaseRepo<NotificationReceiver>, INotificationReceiverRepo
    {
        public NotificationReceiverRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }

        public List<NotificationReceiver> GetAllOfUser(int userId)
        {
            return Where(receiver => receiver.userId == userId).ToList();
        }
    }
}
