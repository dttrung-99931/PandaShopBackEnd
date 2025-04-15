using System.Collections.Generic;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services
{
    public interface IPanVideoService
    {
        CreatePanVideoResponse CreatePanVideo(CreatePanVideoRequest request);
        void DeletePanVideo(int id);
        List<PanVideoResposne> GetMyPanvideos(PanvideoFilter filter, out Meta meta);
        List<PanVideoResposne> GetPanvideos(PanvideoFilter filter, out Meta meta);
        void SetUser(UserIdentifier user);
    }
}