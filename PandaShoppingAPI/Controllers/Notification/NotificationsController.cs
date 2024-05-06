using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Authorize]
    public class NotificationsController : CrudApiController2<Notification, NotificationModel,
            NotificationResponse, INotificationService, NotificationFilter>
    {
        public NotificationsController(INotificationService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor)
        {
        }

        public override ActionResult<ResponseWrapper> Get([FromQuery] NotificationFilter filter)
        {
            return Handle(() =>
            {
                List<NotificationResponse> notis = _service.Get(filter, out Meta meta);
                UpdateNotisSeen(notis);
                return ok_get(notis, meta);
            });
        }

        private void UpdateNotisSeen(List<NotificationResponse> notis)
        {
            List<int> ids = notis.Where(noti => noti.status == UserNotificationStatus.Sent)
                .Select(noti => noti.id)
                .ToList();
            Response.OnCompleted(() =>
            {
                _service.UpdateNotificationStatusToSeen(ids);
                return Task.CompletedTask;
            });
        }

        [HttpGet("Overview")]
        public ActionResult<ResponseWrapper> GetNotificaitonOverview([FromQuery] NotificationFilter filter){
            return Handle(() => {
                NotificationOverviewResponse overview = _service.GetNotificationOverview(filter);
                return ok_get(overview);
            });
        }

        [HttpPost("Receiver")]
        public ActionResult<ResponseWrapper> NotificationReceiver(NotificationReceiverModel model)
        {
            return Handle(() =>
            {
                _service.CreateNotificationReceiver(model);
                return ok_update();
            });
        }


    }
}
