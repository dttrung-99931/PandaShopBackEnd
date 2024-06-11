using System.Collections.Generic;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IDeliveryService: IBaseService<Delivery, DeliveryModel, DeliveryFilter>
    {
        void SetCustomerAddresses(List<DeliveryResponse> deliveries);
    }
}
