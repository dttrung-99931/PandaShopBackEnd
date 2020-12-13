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
    public class CategoryResponse : BaseModel<Category, CategoryResponse>
    {
        public string name { get; set; }
        public string imgLink { get; set; }
        public int? templateId { get; set; }
        public int level { get; set; }

        protected override void CustomMapping(
            IMappingExpression<Category, CategoryResponse> mappingExpression, 
            IConfiguration config)
        {
            mappingExpression.ForMember
            (
                responseCategory => responseCategory.imgLink,
                option => option.MapFrom(
                    category => category.imageId != null 
                        ? Path.Combine(
                            config["Path:CategoryImgEndPoint"], 
                            category.image.fileName
                        ) 
                        : null
                )
            );
        }
    }
}
