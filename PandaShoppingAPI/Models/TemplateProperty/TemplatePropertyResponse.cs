using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class TemplatePropertyResponse: BaseModel<PropertyTemplate, TemplatePropertyResponse>
    {
        [MapTo("property.name")]
        public string propertyName { get; set; }
        public bool? isRequired { get; set; }
        public List<string> values { get; set; }

        protected override void CustomMapping(
            IMappingExpression<PropertyTemplate, TemplatePropertyResponse> mappingExpression, 
            IConfiguration config)
        {
            mappingExpression.ForMember(
                response => response.values,
                action => action.MapFrom
                (
                    propertyTemplate => MyUtil.MapList
                    (
                        propertyTemplate.PropertyTemplateValue.ToList(),
                        pTempValue => pTempValue.value
                    )
                )
            );
        }
    }
}
