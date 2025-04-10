using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaShoppingAPI.Models
{
    public class ProductImageRequest : BaseModel<ProductImage, ProductImageRequest>
    {
        public string based64Img { get; set; }
        public int orderIndex { get; set; }
        public string description { get; set; }
        public int avgColor { get; set; }
    }
}