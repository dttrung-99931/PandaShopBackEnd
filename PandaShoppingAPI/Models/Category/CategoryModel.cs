using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class CategoryModel: BaseModel<Category, CategoryModel>
    {
        public string name { get; set; }
        public int? parentId { get; set; }
        public string based64Img { get; set; }
    }
}
