using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface INotificationService : IBaseService<Notification, NotificationModel, NotificationFilter>
    {
        Notification CreateOrderStatusUpdatedNoti(int orderId);
    }
}
