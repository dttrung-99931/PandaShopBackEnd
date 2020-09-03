using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface ITemplateService : IBaseService<Template, TemplateModel, TemplateFilter>
    {
        void AddPropertyValues(int id, PropertyValuesModel model);
        void UpdatePropertyValues(int id, PropertyValuesModel model);
        void DeletePropertyValues(int id, int propertyId);
    }
}
