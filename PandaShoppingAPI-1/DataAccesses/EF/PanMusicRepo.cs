using System.Collections.Generic;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public class PanMusicRepo
    {
        // This method retrieves the user's PanMusics from the database
        public List<PanMusicResponse> GetMyPanMusics(PanMusicFilter filter)
        {
            // Implementation for retrieving user's PanMusics
        }

        // This method retrieves all PanMusics from the database
        public List<PanMusicResponse> GetPanMusics(PanMusicFilter filter)
        {
            // Implementation for retrieving all PanMusics
        }

        // This method creates a new PanMusic in the database
        public PanMusicResponse CreatePanMusic(CreatePanMusicRequest request)
        {
            // Implementation for creating a new PanMusic
        }

        // This method deletes a PanMusic from the database
        public void DeletePanMusic(int id)
        {
            // Implementation for deleting a PanMusic
        }
    }
}