using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class OrderResponseModel: BaseModel<Order_, OrderResponseModel>
    {
        public string note { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public virtual AddressModel address { get; set; }
        public virtual Delivery delivery { get; set; }
        public virtual PaymentMethod paymentMethod { get; set; }
    }
}
