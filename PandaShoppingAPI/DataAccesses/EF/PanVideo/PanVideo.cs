
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public class PanVideo: BaseEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string fileName { get; set; }
        public string thumbImageFileName { get; set; }
        public int durationInSecs { get; set; }
        public int userId { get; set; }

        public virtual User_ User { get; set; }
    }
}