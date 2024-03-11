using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Controllers
{
    public class AddressesController : BaseApiController<IAddressService>
    {
        public AddressesController(IAddressService service) : base(service)
        {
        }

        [HttpGet("ProvincesAndCities")]
        public ActionResult<ResponseWrapper> GetProvincesAndCities([FromQuery] Filter filter)
        {
            try
            {
                return ok_get(_service.FillProvincesAndCities(filter));
            }
            catch (Exception)
            {
                return unknownError("Server error");
            }
        }

        [HttpGet("CommunesAndWards/{districtCode}")]
        public ActionResult<ResponseWrapper> GetAllCommunesAndWards(string districtCode)
        {
            try
            {
                return ok_get(_service.GetAllCommunesAndWards(districtCode));
            }
            catch (Exception)
            {
                return error(
                    HttpStatusCode.NotFound,
                    string.Format("District_id = {0} is not correct", districtCode));
            }
        }

        [HttpGet("Districts/{provinceOrCityCode}")]
        public ActionResult<ResponseWrapper> GetAllDistricts(string provinceOrCityCode)
        {
            if (!ModelState.IsValid) return error(
                HttpStatusCode.BadRequest,
                GetModelStateErrMsg());

            try
            {
                return ok_get(_service.GetAllDistricts(provinceOrCityCode));
            }
            catch (Exception)
            {
                return error(
                    HttpStatusCode.NotFound,
                    string.Format("provinceOrCityCode = {0} is not correct", provinceOrCityCode));
            }

        }


    }
}
