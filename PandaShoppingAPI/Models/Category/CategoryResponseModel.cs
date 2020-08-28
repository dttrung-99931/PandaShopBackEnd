using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class CategoryResponseModel : BaseModel<Category, CategoryResponseModel>
    {
        public string name { get; set; }
        public int? parentId { get; set; }
    }
}
