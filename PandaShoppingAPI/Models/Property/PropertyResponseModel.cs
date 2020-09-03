using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class PropertyResponseModel : BaseModel<Property, PropertyResponseModel>
    {
        public string name { get; set; }
        public string secondaryId { get; set; }
    }
}
