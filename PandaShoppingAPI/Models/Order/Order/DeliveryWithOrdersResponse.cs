using System.Collections.Generic;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Models.Base;

namespace PandaShoppingAPI.Models
{
    public class DeliveryWithOrdersResponse
    {
        public int id { get; set; }
        public AddressModel deliveryPartnerUnitAddress { get; set; }
        public List<OrderResponseModel> orders;
    }
}
