﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaShoppingAPI.Controllers.Base;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Controllers
{
    [Route("v1/[controller]")]
    public class OrdersController : CrudApiController2<Order, OrderModel,
            OrderResponseModel, IOrderService, OrderFilter>
    {
        private readonly IDeliveryService _deliveryService;
        public OrdersController(IOrderService service, IHttpContextAccessor httpContextAccessor, IDeliveryService deliveryService) : base(service, httpContextAccessor)
        {
            _deliveryService = deliveryService;
        }

        protected override void HandleResponseModel(OrderResponseModel response)
        {
            // Because maspping DeliveryREsponse.customerAddress by AutoMappng  got error. 
            // So We need map customerAddress manually 
            // FIXME: Map by AutoMapper
            // _deliveryService.SetCustomerAddresses(response.Delivery);
            // base.HandleResponseModel(response);
        }

        [Authorize(Roles = "user")]
        [HttpPost(Order = -1)] // Mark -1 to override default insert api route
        public ActionResult<ResponseWrapper> Insert(CreateOrdersModel model)
        {
            return Handle(() =>
            {
                List<Order> orders = _service.Insert(model);
                return ok_create(Constants.SUCCESSFUL_MSG, orders.Select(order => order.id));
            });
        }

        // Hide default insert API
        [ApiExplorerSettings(IgnoreApi = true)] // Hide API in swagger
        public override ActionResult<ResponseWrapper> Post([FromBody] OrderModel requestModel)
        {
            return notFound();
        }

        [Authorize(Roles = "shop")]
        [HttpPut(APIPaths.Orders.startProcessing)]
        public ActionResult<ResponseWrapper> StartProcessingOrder(int id)
        {
            return Handle(() =>
            {
                _service.StartProcessing(id);
                return ok_update();
            });
        }

        [Authorize(Roles = "shop")]
        [HttpPut(APIPaths.Orders.completeProcessing)]
        public ActionResult<ResponseWrapper> CompleteProcessing(int id)
        {
            return Handle(() =>
            {
                _service.CompleteProcessing(id);
                return ok_update();
            });
        }

        [Authorize(Roles = "shop")]
        [HttpGet(APIPaths.Orders.getCompleteProcessingOrders)]
        public ActionResult<ResponseWrapper> GetOrderDeliveries()
        {
            return Handle(() =>
            {
                List<TempDeliveryResponse> tempDeliveries = _service.GetCompleteProcessingOrders();
                return ok_get(tempDeliveries);
            });
        }


        [Authorize(Roles = "shop")]
        [HttpGet(APIPaths.Orders.getWaitingPartnerDeliveryOrders)]
        public ActionResult<ResponseWrapper> GetWaitingPartnerDeliveryOrders()
        {
            return Handle(() =>
            {
                List<DeliveryWithOrdersResponse> tempDeliveries = _service.GetWaitingDeliveryWithOrders();
                return ok_get(tempDeliveries);
            });
        }

        [Authorize(Roles = "shop")]
        [HttpGet(APIPaths.Orders.getDeliveringOrders)]
        public ActionResult<ResponseWrapper> GetDeliveringOrders()
        {
            return Handle(() =>
            {
                List<DeliveryWithOrdersResponse> delivering = _service.GetDeliveringDeliveryWithOrders();
                return ok_get(delivering);
            });
        }

        [Authorize(Roles = "shop")]
        [HttpPost(APIPaths.Orders.requestPartnerDelivery)]
        public ActionResult<ResponseWrapper> RequestPartnerDelivery([FromBody] RequestPartnerDeliveryModel requestModel)
        {
            return Handle(() =>
            {
                _service.RequestPartnerDelivery(requestModel);
                return ok_update();
            });
        }

    }
}
