using System.Collections.Generic;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public interface IPanMusicService
    {
        List<PanMusicResponse> GetMyPanMusics(PanMusicFilter filter, out Meta meta);
        List<PanMusicResponse> GetPanMusics(PanMusicFilter filter, out Meta meta);
        CreatePanMusicResponse CreatePanMusic(CreatePanMusicRequest request);
        void DeletePanMusic(int id);
    }
}