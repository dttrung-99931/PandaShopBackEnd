using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace PandaShoppingAPI.Models
{
    public class ProductImageResponse : BaseModel<ProductImage, ProductImageResponse>
    {
        public string link { get; set; }
        public string description { get; set; }

        protected override void CustomMapping(IMappingExpression<ProductImage, ProductImageResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember
            (
                pImgRes => pImgRes.link,
                option => option.MapFrom(
                        productImg => Path.Combine(
                                    config["Path:ProductImgEndPoint"],
                                    productImg.image.fileName)
                )
            );
        }
    }
}