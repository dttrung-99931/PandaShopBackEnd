using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            Feedback = new HashSet<Feedback>();
            ProductDeliveryMethod = new HashSet<ProductDeliveryMethod>();
            ProductImage = new HashSet<ProductImage>();
            ProductOption = new HashSet<ProductOption>();
            ProductPropertyValue = new HashSet<ProductPropertyValue>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public double starNum { get; set; }
        public string description { get; set; }
        public int sellingNum { get; set; }
        public int remainingNum { get; set; }
        public int categoryId { get; set; }
        public int shopId { get; set; }
        public int addressId { get; set; }
        

        public virtual Address address { get; set; }
        public virtual Category category { get; set; }
        public virtual Shop shop { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
        public virtual ICollection<ProductDeliveryMethod> ProductDeliveryMethod { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<ProductOption> ProductOption { get; set; }
        public virtual ICollection<ProductPropertyValue> ProductPropertyValue { get; set; }
    }
}
