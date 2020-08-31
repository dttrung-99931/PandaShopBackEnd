using AutoMapper.Configuration.Conventions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.Models
{

    public class ImageResponseModel
    {
        public int id { get; set; }

        public string link { get; set; }
        public string description { get; set; }
        //public DateTime created_at { get; set; }
    }


}