using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PandaShoppingAPI.Models
{
    public class UpdatePanMusicRequest
    {
        public IFormFile music { get; set; }
        public string title { get; set; }
        public int? durationInSecs { get; set; }
    }
}