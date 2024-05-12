using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class Driver: BaseEntity
    {
        public int id { get; set; }
        [Precision(12, 9)]
        public decimal lat { get; set; }
        [Precision(12, 9)]
        public decimal long_ { get; set; }
        public virtual User_ user { get; set; }
    }
}
