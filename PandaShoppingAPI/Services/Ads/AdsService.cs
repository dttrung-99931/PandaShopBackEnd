﻿using AutoMapper;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using PandaShoppingAPI.Utils.ServiceUtils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class AdsService: IAdsService
    {
        private readonly IProductRepo _productRepo;
        private readonly IConfiguration _config;

        public AdsService(IProductRepo productRepo, IConfiguration config)
        {
            _productRepo = productRepo;
            _config = config;
        }

        public List<BannerResponse> GetHomeBanners()
        {
            List<Product> bannerProducts = _productRepo.GetIQueryable()
                .Where((product) => product.ProductImage.Any())
                .OrderBy((product) => product.starNum)
                .Take(10)
                .ToList();
            return bannerProducts.Select((product) =>
            {
                var firstProImage = product.ProductImage.First();
                return new BannerResponse
                {
                    imageLink = ImageUtils.BuildProductImageLink(_config, firstProImage),
                    avgColor = firstProImage.image.avgColor ?? 0,
                };
            })
                .ToList();
        }
    }
}
