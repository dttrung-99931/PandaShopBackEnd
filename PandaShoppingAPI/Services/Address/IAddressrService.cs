namespace PandaShoppingAPI.Services
{
    public interface IAddressService
    {
        object FillProvincesAndCities(Filter filter);
        object GetAllCommunesAndWards(string district_id);
        object GetAllDistricts(string province_or_city_id);
    }
}
