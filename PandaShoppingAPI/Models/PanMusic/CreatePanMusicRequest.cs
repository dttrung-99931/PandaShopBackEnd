using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PandaShoppingAPI.Models 
{
    public class CreatePanMusicRequest
    {
        [Required]
        public IFormFile music { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int durationInSecs { get; set; }
    }
}