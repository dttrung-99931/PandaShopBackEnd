using PandaShoppingAPI.DataAccesses.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public interface IPropertyTemplateValueRepo : IBaseRepo<PropertyTemplateValue>
    {
        void InsertRange(int propertyTemplateId, List<string> values);
        void UpdateOrInsertValues(int templatePropertyId, List<string> values);
    }
}
