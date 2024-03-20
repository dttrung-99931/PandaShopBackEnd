using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace PandaShoppingAPI.Models
{

    public class AddressResponseModel : BaseModel<Address, AddressResponseModel>
    {
        public string provinceOrCity { get; set; }
        public string provinceOrCityCode { get; set; }
        public string district { get; set; }
        public string districtCode { get; set; }
        public string communeOrWard { get; set; }
        public string streetAndHouseNum { get; set; }
    }


}