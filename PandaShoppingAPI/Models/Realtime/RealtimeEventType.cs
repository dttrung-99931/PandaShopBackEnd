using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public enum RealtimeEventType
    {
        DriverTakeDelivery = 1, 
        DeliveryProgressUpdate = 4, 
    }
}
