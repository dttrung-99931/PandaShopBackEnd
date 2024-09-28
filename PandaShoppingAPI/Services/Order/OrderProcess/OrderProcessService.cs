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
        public void RequestDelivery(int deliveryId)
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
                .Where(delivery => delivery.orderId == deliveryId && delivery.DeliveryLocation.Any(
                    location => location.locationType == LocationType.Delivery))
                .FirstOrDefault();

            if (endCustomerDelivery == null)
            {
                throw new Exception($"order {deliveryId} has no init default customer delivery");
            }

            int pickupAddressId = defaultWareHourse.addressId; 
            Delivery pickUpDelivery = new Delivery 
            {
                status = DeliveryStatus.Created,
                orderId = deliveryId,
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
            UpdateOrderStatus(deliveryId, OrderStatus.WaitingForDelivering);
        }

        public void StartProcessing(int orderId)
        {
            UpdateOrderStatus(orderId, OrderStatus.Processing);
        }

        public void CompleteProcessing(int orderId)
        {
            UpdateOrderStatus(orderId, OrderStatus.CompleteProcessing);
        }

        private void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            Order order = _repo.GetById(orderId);
            order.status = status;
            _repo.Update(order, order.id);
        }
    }
}
