namespace PandaShoppingAPI.Models.PanMusic
{
    public class CreatePanMusicRequest
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; } // Duration in seconds
        public string FilePath { get; set; }
    }
}