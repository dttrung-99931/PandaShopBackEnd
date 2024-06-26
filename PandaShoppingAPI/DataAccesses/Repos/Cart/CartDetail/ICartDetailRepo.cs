﻿using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public interface ICartDetailRepo: IBaseRepo<CartDetail>
    {
        void DeleteCartItems(int cartId, IEnumerable<int> productOptionsIds);

    }
}
