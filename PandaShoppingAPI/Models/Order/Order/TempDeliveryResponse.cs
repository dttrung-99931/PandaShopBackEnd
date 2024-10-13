using System.Collections.Generic;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Models
{
    public class TempDeliveryResponse 
    {
        public AddressModel deliveryPartnerUnitAddress { get; set; }
        public List<OrderResponseModel> orders;
    }
}
