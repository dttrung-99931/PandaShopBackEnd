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
    public class CategoryResponseModel : BaseModel<Category, CategoryResponseModel>
    {
        public string name { get; set; }
        public string imgLink { get; set; }
        //public int? parentId { get; set; }
        //public int level { get; set; }

        protected override void CustomMapping(
            IMappingExpression<Category, CategoryResponseModel> mappingExpression, 
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
