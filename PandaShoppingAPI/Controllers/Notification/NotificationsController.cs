﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class NotificationsController : CrudApiController2<Notification, NotificationModel,
            NotificationResponse, INotificationService, NotificationFilter>
    {
        public NotificationsController(INotificationService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
        }

        [HttpGet("Overview")]
        public ActionResult<ResponseWrapper> GetNotificaitonOverview([FromQuery] NotificationFilter filter){
            return Handle(() => {
                NotificationOverviewResponse overview = _service.GetNotificationOverview(filter);
                return ok_get(overview);
            });
        }
    }
}
