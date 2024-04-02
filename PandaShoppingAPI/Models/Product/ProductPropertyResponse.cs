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
    public class ProductPropertyResponse : 
        BaseModel<ProductPropertyValue, ProductPropertyResponse>
    {
        public string name { get; set; }
        public string value { get; set; }
        public int propertyId { get; set; }

        protected override void CustomMapping(IMappingExpression<ProductPropertyValue, ProductPropertyResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember(
                response => response.name,
                action => action.MapFrom(
                    productProperty => productProperty.property.name));
        }
    }
}
