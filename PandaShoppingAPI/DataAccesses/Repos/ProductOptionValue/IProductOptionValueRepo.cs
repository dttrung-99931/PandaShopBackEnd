using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public interface IProductOptionValueRepo : IBaseRepo<ProductOptionValue>
    {
        void InsertRange(int productOptId, List<PropertyValueRequest> properties);
    }
}
