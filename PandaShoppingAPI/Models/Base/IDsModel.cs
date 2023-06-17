using System.Collections.Generic;

namespace PandaShoppingAPI.Models.Base
{
    public class IDsResponseModel 
    {
        public List<int> IDs { get; set; }

        public IDsResponseModel(List<int> iDs)
        {
            IDs = iDs;
        }
    }
}
