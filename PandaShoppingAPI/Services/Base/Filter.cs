using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class Filter
    {
        public string q { get; set; }
        public int? pageSize { get; set; }
        public int? pageNum { get; set; }

        public  string UnescapeQ()
        {
            return Uri.UnescapeDataString(q);
        }

    }
}
