using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IPanVideoService
    {
        PanVideoResponse CreatePanVideo(PanVideoRequest request);
        void DeletePanVideo(int id);
        void SetUser(UserIdentifier user);
    }
}