
using System;
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public enum OrderStatus
    {
        Created = 1, // Successful created order 
        Pending = 4, // when order with pay now method and pending for payemnt completed
        Processing = 12, // When shop comfirmed order and processing
        CancelledByBuyer = 16,
        CancelledByShop = 20,
        CompleteProcessing = 22, // Shopper complete processing, but have been not requested to delivery
        WaitingForDelivering = 24, // Shopper requested delivery and waiting for delivering
                                    // at this time, a pick up delivery will be created for the order
        Delivering = 28, // Delivering
        Delivered = 32, // Deliveried, buyer received the product
        CompletedByUser = 36, // User comfirm completed order 
        CompletedBySystem = 40, // order completed after a duration from Deliveried date
        Lost = 44, // Order is loosed, Thất lạc

    }
}

