using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.DataAccesses.Repos 
{
    public class PanMusicRepo : BaseRepo<PanMusic>, IPanMusicRepo
    {
        public PanMusicRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}