using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaShoppingAPI.Models
{
    public class ImageModel: BaseModel<Image, ImageModel>
    {
        public string based64Img { get; set; }
        public string description { get; set; }
    }
}