using AutoMapper;
using Microsoft.Extensions.Configuration;
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
    public class CurrentDeliveryResponse : BaseModel<Delivery, CurrentDeliveryResponse>
    {
        public DateTime? startedAt { get; set; }
        public DateTime? finishedAt { get; set; }
        public DeliveryStatus status { get; set; }
        public DeliveryMethodResponse deliveryMethod { get; set; }
        
        [JsonProperty("deliveryLocations")]
        public List<DeliveryLocationResponse> DeliveryLocation { get; set; }
        
        [JsonProperty("progress")]
        public DeliveryProgressModel deliveryDriver { get; set; }

        protected override void CustomMapping(IMappingExpression<Delivery, CurrentDeliveryResponse> mappingExpression, IConfiguration config)
        {
            // Sort delivery locations by order

            mappingExpression
                .ForMember(
                    delivery => delivery.DeliveryLocation,
                    option => option.MapFrom(
                        delivery => delivery.DeliveryLocation.OrderBy(location => location.locationOrder))
                );

        }
    }
}
