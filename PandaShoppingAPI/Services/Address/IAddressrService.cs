using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IAddressService: IBaseService<Address, AddressModel, Filter>
    {
        object FillProvincesAndCities(Filter filter);
        object GetAllCommunesAndWards(string district_id);
        object GetAllDistricts(string province_or_city_id);
    }
}
