using System.Collections.Generic;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Models.Base;

namespace PandaShoppingAPI.Models
{
    public class DeliveryWithOrdersResponse
    {
        public int id { get; set; }
        public DeliveryStatus status { get; set; }
        public DeliveryProgressModel progress { get; set; }
        public AddressModel deliveryPartnerUnitAddress { get; set; }
        public List<OrderResponseModel> orders;
    }
}
