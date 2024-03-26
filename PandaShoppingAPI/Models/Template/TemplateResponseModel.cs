using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class TemplateResponseModel : BaseModel<Template, TemplateResponseModel>
    {
        [JsonProperty("properties")]
        public List<TemplatePropertyResponse> PropertyTemplate { get; set; }

    }
}
