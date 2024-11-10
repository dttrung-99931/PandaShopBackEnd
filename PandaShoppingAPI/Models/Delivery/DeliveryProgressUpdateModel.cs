using Newtonsoft.Json;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class DeliveryProgressUpdateModel
    {
        public int id { get; set; }
        public DeliveryStatus status { get; set; }
        public DeliveryProgressModel progress { get; set; }

        public string ToJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

    }
}
