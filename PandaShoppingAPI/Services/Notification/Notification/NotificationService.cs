using AutoMapper;
using Castle.Core.Internal;
using PandaShoppingAPI.Configs.Messages;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public partial class NotificationService : BaseService<INotificationRepo, Notification, NotificationModel, NotificationFilter>, 
        INotificationService
    {
        private readonly IUserNotificationRepo _userNotiRepo;
        private readonly INotificationReceiverRepo _notiReceiverRepo;
        private readonly IOrderRepo _orderRepo;
        private readonly INotificationSenderService _notiSenderService;
        private readonly IDeliveryRepo _deliveryRepo;

        public NotificationService(
            INotificationRepo repo,
            IUserNotificationRepo userNotiRepo,
            INotificationReceiverRepo notiReceiverRepo,
            IOrderRepo orderRepo,
            INotificationSenderService notiSenderService,
            IDeliveryRepo deliveryRepo) : base(repo)
        {
            _userNotiRepo = userNotiRepo;
            _notiReceiverRepo = notiReceiverRepo;
            _orderRepo = orderRepo;
            _notiSenderService = notiSenderService;
            _deliveryRepo = deliveryRepo;
        }
    }
}
