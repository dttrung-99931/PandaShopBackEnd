using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class PropertyModel: BaseModel<Property, PropertyModel>
    {
        public string name { get; set; }
        public string secondaryId { get; set; }
    }
}
