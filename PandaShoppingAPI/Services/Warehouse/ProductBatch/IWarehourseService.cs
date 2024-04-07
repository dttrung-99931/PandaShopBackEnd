using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public interface IProductBatchService: IBaseService<ProductBatch, ProductBatchModel, Filter>
    {
    }
}
