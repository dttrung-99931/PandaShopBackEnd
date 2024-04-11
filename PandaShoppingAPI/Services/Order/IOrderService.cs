using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IOrderService: IBaseService<Order_, OrderModel, OrderFilter>
    {
    }
}
