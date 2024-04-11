using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IDeliveryService: IBaseService<Delivery, DeliveryModel, DeliveryFilter>
    {
    }
}
