using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class ProductDeliveryMethod : BaseEntity
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int deliveryMethodId { get; set; }
        

        public virtual DeliveryMethod deliveryMethod { get; set; }
        public virtual Product product { get; set; }
    }
}
