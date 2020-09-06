using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public interface ITemplateService : IBaseService<Template, TemplateModel, TemplateFilter>
    {
        void AddPropertyValues(int id, PropertyValuesModel model);
        void UpdatePropertyValues(int id, PropertyValuesModel model);
        void DeletePropertyValues(int id, int propertyId);
        List<int> GetRequiredPropertyIDs(int templateId);
    }
}
