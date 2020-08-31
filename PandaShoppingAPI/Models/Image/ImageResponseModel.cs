using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace PandaShoppingAPI.Models
{

    public class ImageResponseModel: BaseModel<Image, ImageResponseModel>
    {
        public string link { get; set; }
        public string description { get; set; }
    }


}