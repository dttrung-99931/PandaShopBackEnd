﻿using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class ImageRepo : BaseRepo<Image>, IImageRepo
    {
        public ImageRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
