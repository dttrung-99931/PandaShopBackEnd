using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class User_ : BaseEntity
    {
        public User_()
        {
            Address = new HashSet<Address>();
            Feedback = new HashSet<Feedback>();
            Order_ = new HashSet<Order_>();
            UserRole = new HashSet<UserRole>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int cartId { get; set; }
        public int? shopId { get; set; }
        

        public virtual Cart cart { get; set; }
        public virtual Shop shop { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
        public virtual ICollection<Order_> Order_ { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
