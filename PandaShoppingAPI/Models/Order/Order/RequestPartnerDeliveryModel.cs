using System.Collections.Generic;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Models
{
    public class RequestPartnerDeliveryModel 
    {
        public int deliveryPartnerUnitId { get; set; }
        public int deliveryPartnerUnitAddressId { get; set; }
        public int deliveryMethodId { get; set; }
        public List<int> orderIds;
    }
}
