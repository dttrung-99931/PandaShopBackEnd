using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Utils.Extentions
{
    public static class CommonExtentions
    {
        public static string Unescaped(this string str)
        {
            return Uri.UnescapeDataString(str);
        }
    }
}
