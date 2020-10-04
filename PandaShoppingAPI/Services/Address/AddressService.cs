using Newtonsoft.Json.Linq;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public class AddressService : IAddressService
    {
        public object GetAllCommunesAndWards(string district_id)
        {
            return GetAddressJArray("communes_and_wards", district_id);
        }

        private JArray GetAddressJArray(string directoryName, string fileId = "")
        {
            string relativePath = directoryName;
            
            if (fileId != "") relativePath += "\\" + fileId + ".json";
            else relativePath += ".json";

            string specifiedPath = MyUtil.GetAppDataFilePath(relativePath);

            string content = MyUtil.ReadFileContent(specifiedPath);

            return JArray.Parse(content);
        }

        public object GetAllDistricts(string province_or_city_id)
        {
            return GetAddressJArray("districts", province_or_city_id);
        }

        public object FillProvincesAndCities(Filter filter)
        {
            var allProvincesAndCities = GetAddressJArray("provinces_and_cities");

            JArray filteredProvinceAndCities = fillProvincesAndCitiesByQ(
                allProvincesAndCities, filter);

            return MyUtil.Page(filteredProvinceAndCities,
                filter.pageSize, filter.pageNum);
        }

        private JArray fillProvincesAndCitiesByQ(JArray allProvincesAndCities, Filter filter)
        {
            var filteredProvinceAndCities = new JArray();

            if (!string.IsNullOrEmpty(filter.q))
            {
                foreach (var provinceOrCity in allProvincesAndCities.AsJEnumerable())
                {
                    var name = provinceOrCity.Value<string>("name");
                    if (name.Contains(filter.UnescapeQ(), StringComparison.OrdinalIgnoreCase))
                    {
                        filteredProvinceAndCities.Add(provinceOrCity);
                    }
                }
            }
            else
            {
                filteredProvinceAndCities = allProvincesAndCities;
            }

            return filteredProvinceAndCities;
        }
    }
}
