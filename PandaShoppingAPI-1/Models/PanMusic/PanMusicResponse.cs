namespace PandaShoppingAPI.Models.PanMusic
{
    public class PanMusicResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public string Url { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}