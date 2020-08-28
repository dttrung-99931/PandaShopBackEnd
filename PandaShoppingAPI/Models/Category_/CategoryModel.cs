using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models.Category_
{
    public class CategoryModel: BaseModel<Category, CategoryModel>
    {
        public string name { get; set; }
    }
}
