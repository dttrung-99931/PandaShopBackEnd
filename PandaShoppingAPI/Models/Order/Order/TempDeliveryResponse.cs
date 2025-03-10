using System.Collections.Generic;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Models
{
    public class TempDeliveryResponse 
    {
        public int deliveryPartnerUnitId { get; set; }
        public int deliveryMethodId { get; set; }
        public AddressModel deliveryPartnerUnitAddress { get; set; }
        public List<OrderResponseModel> orders;
    }
}
