using AutoMapper;
using Microsoft.Extensions.Configuration;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class DeliveryResponse : BaseModel<Delivery, DeliveryResponse>
    {
        public DateTime? startedAt { get; set; }
        public DateTime? finishedAt { get; set; }
        public DeliveryStatus status { get; set; }
        public DeliveryMethodResponse deliveryMethod { get; set; }
        // Will be map in DeliveryService
        public AddressResponseModel customerAddress { get; set; }
        
        // FIXME: Mapping customerAddress not working
        // protected override void CustomMapping(IMappingExpression<Delivery, DeliveryResponse> mappingExpression, IConfiguration config)
        // {
        //     mappingExpression.ForMember
        //     (
        //         delivery => delivery.customerAddress,
        //         option => option.MapFrom(delivery => Mapper.Map<AddressResponseModel>(
        //                     delivery.DeliveryLocation.FirstOrDefault()
        //                 )
        //             )
        //         );

        // }
    }
}
