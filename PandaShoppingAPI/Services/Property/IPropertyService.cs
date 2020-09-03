using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IPropertyService: IBaseService<Property, PropertyModel, PropertyFilter>
    {
    }
}
