using System;
using System.Collections.Generic;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;

namespace PandaShoppingAPI.Models
{
    public partial class DeliveryLocationResponse: BaseModel<DeliveryLocation, DeliveryLocationResponse>
    {
        public int locationOrder { get; set; }
        public LocationType locationType { get; set; }
        public virtual AddressResponseModel address { get; set; }
    }
}
