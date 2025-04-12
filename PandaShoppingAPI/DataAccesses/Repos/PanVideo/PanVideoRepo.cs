using PandaShoppingAPI.DataAccesses.EF;

namespace PandaShoppingAPI.DataAccesses.Repos 
{
    public class PanVideoRepo : BaseRepo<PanVideo>, IPanVideoRepo
    {
        public PanVideoRepo(EcommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}