
using System.Collections.Generic;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public class PanMusic: BaseEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public string fileName { get; set; }
        public int durationInSecs { get; set; }
        public int userId { get; set; }
        
        public virtual User_ User { get; set; }
        public virtual ICollection<PanVideo> PanVideos { get; set; }
    }
}