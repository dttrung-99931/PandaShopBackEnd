using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class Filter
    {
        public string q { get; set; }
        public int? page_size { get; set; }
        public int? page_number { get; set; }
    }
}
