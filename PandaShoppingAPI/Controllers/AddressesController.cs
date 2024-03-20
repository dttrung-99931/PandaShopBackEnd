using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    [Authorize]
    public class AddressesController : CrudApiController2<Address, AddressModel, AddressModel, IAddressService, Filter>
    {
        public AddressesController(IAddressService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
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
