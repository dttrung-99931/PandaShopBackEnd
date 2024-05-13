using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;

namespace PandaShoppingAPI.Models
{
    public class DriverModel : BaseModel<Driver, DriverModel>
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        
        // TDOO:
        public string licensePlates { get; set; } // Biển số xe
        public int addressId { get; set; } // Biển số xe

        public UserModel ToUserModel()
        {
            return new UserModel
            {
                name = name,
                email = email,
                phone = phone,
                password = password,
            };
        }
    }
}
