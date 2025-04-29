using System.Collections.Generic;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils;

namespace PandaShoppingAPI.Services
{
    public interface IPanMusicService
    {
        void SetUser(UserIdentifier user);
        List<PanMusicResposne> GetMyPanMusics(PanMusicFilter filter, out Meta meta);
        List<PanMusicResposne> GetPanMusics(PanMusicFilter filter, out Meta meta);
        CreatePanMusicResponse CreatePanMusic(CreatePanMusicRequest request);
        void DeletePanMusic(int id);
    }
}