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
        void InsertRange(int productId, List<ProductOptionRequest> productOptions);
        void UpsertRange(int productId, List<ProductOptionRequest> productOptions);
        void UpdateRange(int productId, List<ProductOptionRequest> productOptions);
        ProductOption Insert(int productId, ProductOptionRequest option);
    }
}
