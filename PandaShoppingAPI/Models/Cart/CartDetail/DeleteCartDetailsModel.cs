using Newtonsoft.Json;
using System.Collections.Generic;

namespace PandaShoppingAPI.Models
{
    public class DeleteCartItemsModel
    {
        public List<int> itemIds { get; set; } // Cart detail ids
    }
}
