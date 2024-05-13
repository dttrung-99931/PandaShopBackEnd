using Microsoft.EntityFrameworkCore;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace PandaShoppingAPI.Models
{
    public class AddressModel: BaseModel<Address, AddressModel>
    {
        public string provinceOrCity { get; set; }
        public string provinceOrCityCode { get; set; }
        public string district { get; set; }
        public string districtCode { get; set; }
        public string communeOrWard { get; set; }
        public string streetAndHouseNum { get; set; }
        public string name { get; set; }
        public decimal lat { get; set; }
        [JsonPropertyName("long")]
        public decimal long_ { get; set; }

    }
}