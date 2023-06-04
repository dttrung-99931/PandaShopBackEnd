using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class ProductPropertyValueRepo : BaseRepo<ProductPropertyValue>, IProductPropertyValueRepo
    {
        public ProductPropertyValueRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }

        public void InsertRange(int productId, List<PropertyValueRequest> properties)
        {
            InsertRange(CreatePropertyValues(productId, properties));
        }

        private List<ProductPropertyValue> CreatePropertyValues(
            int productId, List<PropertyValueRequest> properties)
        {
            var propertyValues = new List<ProductPropertyValue>();
            properties.ForEach(
                propertyValue => propertyValues.Add
                (
                    new ProductPropertyValue()
                    {
                        productId = productId,
                        propertyId = propertyValue.propertyId,
                        value = propertyValue.value
                    }
                )
            );
            return propertyValues;
        }
    }
}
