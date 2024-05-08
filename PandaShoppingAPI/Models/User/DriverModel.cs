using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class DriverModel: UserModel
    {
        public string licensePlates { get; set; } // Biển số xe
        public int addressId { get; set; } // Biển số xe
    }
}
