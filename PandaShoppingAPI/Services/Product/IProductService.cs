﻿using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public interface IProductService : IBaseService<Product, ProductModel, ProductFilter>
    {
        void UpdatePropertyValue(int productId, PropertyValueRequest propertyValueReq);
        void UpdatePropertyValues(int productId, List<PropertyValueRequest> propertyValueReqs);
        void DeletePropertyValues(int id, List<int> propertyValueIDs);
    }
}