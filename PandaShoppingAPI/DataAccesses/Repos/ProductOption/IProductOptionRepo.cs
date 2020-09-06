using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public interface IProductOptionRepo : IBaseRepo<ProductOption>
    {
        void InsertRange(int productId, List<ProductOptionModel> productOptions);
    }
}
