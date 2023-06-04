using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class ProductOptionValueRepo : BaseRepo<ProductOptionValue>, IProductOptionValueRepo
    {
        public ProductOptionValueRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }

        public void InsertRange(int productOptId, List<PropertyValueRequest> properties)
        {
            InsertRange(CreatePropertyValues(productOptId, properties));
        }

        private List<ProductOptionValue> CreatePropertyValues(
            int productOptId, List<PropertyValueRequest> properties)
        {
            var propertyValues = new List<ProductOptionValue>();
            properties.ForEach(
                propertyValue => propertyValues.Add
                (
                    new ProductOptionValue()
                    {
                        productOptionId = productOptId,
                        propertyId = propertyValue.propertyId,
                        value = propertyValue.value
                    }
                )
            );
            return propertyValues;
        }
    }
}
