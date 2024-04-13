using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Utils
{
    public class Constants
    {
        public const string CLAIM_USER_ID = "user_id";
        public const string CLAIM_CART_ID = "cart_id";
        public const string CLAIM_ACCOUNT_ID = "account_id";
        public const string POLICY_CORS_ALL = "PolicyAll";
        public const string POLICY_UPLOAD_FILE = "PolicyUpdateFile";
        public const string ID_MODEL_MAINTENANCE = "model";
        public const string ID_OIL_MAINTENACE = "oil";

        public static string fileSep = OperatingSystem.IsWindows() ? "\\" : "/";

        public const string SUCCESSFUL_MSG = "Successful";

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
