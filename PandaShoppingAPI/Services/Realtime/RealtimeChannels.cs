using AutoMapper;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;
using PandaShoppingAPI.Utils.Exceptions;
using PandaShoppingAPI.Utils.ServiceUtils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class RelatimeChannels
    {
        public static string onDeliveryProgress = "onDeliveryProgress";
        public static string onDriverTakeDelivery = "onDriverTakeDelivery";
        public const string onNotification = "onNotification";
    }
}
