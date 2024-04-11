using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IDeliveryMethodService: IBaseService<DeliveryMethod, DeliveryMethodModel, Filter>
    {
    }
}
