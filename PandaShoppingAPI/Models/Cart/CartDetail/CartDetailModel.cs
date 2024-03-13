using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class CartDetailModel : BaseModel<CartDetail, CartDetailModel>
    {
        public int productNum { get; set; }
        public int productOptionId { get; set; }
    }
}
