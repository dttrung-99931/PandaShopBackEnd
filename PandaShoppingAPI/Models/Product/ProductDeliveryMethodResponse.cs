using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class ProductDeliveryMethodResponse: BaseModel<ProductDeliveryMethod, ProductDeliveryMethodResponse>
    {
        public string deliveryMethodName { get; set; }
        public int deliveryMethodId { get; set; }
        public int deliveryPartnerUnitId { get; set; }

    }
}
