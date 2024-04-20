using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Feedback: BaseEntity
    {
        public Feedback()
        {
            Inverseparent = new HashSet<Feedback>();
        }

        public int id { get; set; }
        public string content { get; set; }
        public double? starNum { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int parentId { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        

        public virtual Feedback parent { get; set; }
        public virtual Product product { get; set; }
        public virtual User_ user { get; set; }
        public virtual ICollection<Feedback> Inverseparent { get; set; }
    }
}
