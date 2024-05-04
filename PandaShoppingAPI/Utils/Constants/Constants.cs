using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.Utils
{
    public class Constants
    {
        public const string CLAIM_USER_ID = "user_id";
        public const string CLAIM_CART_ID = "cart_id";
        public const string CLAIM_ACCOUNT_ID = "account_id";
        public const string CLAIM_SHOP_ID = "shop_id";
        public const string POLICY_CORS_ALL = "PolicyAll";
        public const string POLICY_UPLOAD_FILE = "PolicyUpdateFile";
        public const string ID_MODEL_MAINTENANCE = "model";
        public const string ID_OIL_MAINTENACE = "oil";

        public static string fileSep = OperatingSystem.IsWindows() ? "\\" : "/";

        public const string SUCCESSFUL_MSG = "Successful";
        public static List<int> SUCESS_HTTP_CODES = new List<int> {
            200,
            201,
            204
        };
        public const int EMPTY_ID = -1;
        public const string QUERY_PARAM_ACCESS_TOKEN = "access_token";


        // Order status groups that used for dertimine noti for who
        public static List<OrderStatus> StatusesByShop = new List<OrderStatus>
        {
            OrderStatus.Processing,
            OrderStatus.WaitingForDelivering,
            OrderStatus.Delivered,
            OrderStatus.Delivered,
            OrderStatus.CancelledByShop,
            OrderStatus.CompletedBySystem,
        };
        public static List<OrderStatus> StatusesByUser = new List<OrderStatus>
        {
            OrderStatus.Pending,
            OrderStatus.Created,
            OrderStatus.CompletedByUser,
            OrderStatus.Lost,
        };

        public class Headers {
            public const string createdIds = "createdIds";
        }
    }

    // TODO: Create init sql to create init role with specific id like defined in the enums
    public enum Roles
    {
        user = 1,
        shop = 2,
        admin = 3
    }

    public class RoleNames
    {
        public const string user = "user";
        public const string admin = "admin";
        public const string shop = "shop";
    }

}
