using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public partial class OrderService
    {
        // Complete process order 
        // 
        // Create a picker delivery for drivers going to the shop to pick up the package
        // Update order.status to OrderStatus.WaitingForDelivering
        public void CompleteProcessingOrder(int orderId)
        {
            // Currently, all pickup deliveries will have address = the first shop's warehouse address for build PandaDriver faterer
            // TODO: in the fututure, impl feature of selecting driver pick up address for shop when complete a processing order  
            Warehouse defaultWareHourse = _warehouseRepo
                .Where(warehouse => warehouse.shopId == User.ShopId)
                .FirstOrDefault();
            
            if (defaultWareHourse == null)
            {
                throw new Exception($"Shop {User.ShopId} has no warehouse");
            }

            Delivery endCustomerDelivery = _deliveryRepo
                .Where(delivery => delivery.orderId == orderId && delivery.DeliveryLocation.Any(
                    location => location.locationType == LocationType.Delivery))
                .FirstOrDefault();

            if (endCustomerDelivery == null)
            {
                throw new Exception($"order {orderId} has no init default customer delivery");
            }

            int pickupAddressId = defaultWareHourse.addressId; 
            Delivery pickUpDelivery = new Delivery 
            {
                status = DeliveryStatus.Created,
                orderId = orderId,
                deliveryMethodId = endCustomerDelivery.deliveryMethodId,
                DeliveryLocation = new List<DeliveryLocation> 
                {   
                    new DeliveryLocation 
                    {
                        addressId = pickupAddressId,
                        locationType = LocationType.Pickup,
                        locationOrder = 1,
                    },
                    // Fake location partner where shiper will take the package to 
                    new DeliveryLocation 
                    {
                        addressId = 23,
                        // addressId = 13, // use this addressId when db reset 
                        locationType = LocationType.DeliveryPartner,
                        locationOrder = 2,
                    },
                }
            };
            _deliveryRepo.Insert(pickUpDelivery);
            UpdateOrderStatus(orderId, OrderStatus.WaitingForDelivering);
        }

        public void StartProcessingOrder(int orderId)
        {
            UpdateOrderStatus(orderId, OrderStatus.Processing);
        }

        private void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            Order order = _repo.GetById(orderId);
            order.status = status;
            _repo.Update(order, order.id);
        }
    }
}
