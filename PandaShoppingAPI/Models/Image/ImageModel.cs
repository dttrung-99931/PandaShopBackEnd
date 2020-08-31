using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaShoppingAPI.Models
{
    public class ImageModel
    {
        public int id { get; set; }
        public string based64Img { get; set; }
        public string description { get; set; }
    }
}