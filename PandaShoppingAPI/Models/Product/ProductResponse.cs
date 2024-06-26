﻿using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using PandaShoppingAPI.Utils.ServiceUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class ShortProductResponse : BaseModel<Product, ShortProductResponse>
    {
        public string name { get; set; }
        public double starNum { get; set; }
        public int sellingNum { get; set; }
        public int remainingNum { get; set; }
        public string thumbImgLink { get; set; }

        /*The price of the first product option*/
        public decimal firstPrice { get; set; }
        public string sentFrom { get; set; }

        protected override void CustomMapping(IMappingExpression<Product, ShortProductResponse> mappingExpression, IConfiguration config)
        {
            mappingExpression.ForMember
            (
                thumbProduct => thumbProduct.thumbImgLink,
                option => option.MapFrom(
                        product => product.ProductImage.Count != 0
                                ? ImageUtils.BuildProductImageLink(config, product.ProductImage.First())
                                : null
                )
            )
            .ForMember
            (
                thumbProduct => thumbProduct.firstPrice,
                option => option.MapFrom(
                        product => product.ProductOption.Count != 0
                            ? product.ProductOption.First().price
                            : -69
                )
            )
            .ForMember
            (
                thumbProduct => thumbProduct.sentFrom,
                option => option.MapFrom(
                        product => product.address.provinceOrCity
                )
            );
        }

    }


}
