using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class OptionPropertyResponse: 
        BaseModel<ProductOptionValue, OptionPropertyResponse>
    {
        public string name { get; set; }
        public string value { get; set; }

        protected override void CustomMapping(IMappingExpression<ProductOptionValue, OptionPropertyResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember(
            response => response.name,
            action => action.MapFrom(
                optionProperty => optionProperty.property.name));
        }
    }
}
