using Newtonsoft.Json.Linq;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandaShoppingAPI.Services
{
    public class AddressService : BaseService<IAddressRepo, Address, AddressModel, Filter>, IAddressService
    {
        public AddressService(IAddressRepo repo) : base(repo)
        {
        }


        public override IQueryable<Address> Fill(Filter filter)
        {
            return base.Fill(filter).Where((address) => User == null || address.userId == User.UserId);
        }

        protected override Address MapInsertEntity(AddressModel requestModel)
        {
            Address entity = base.MapInsertEntity(requestModel);
            entity.userId = User?.UserId;
            return entity;
        }

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
