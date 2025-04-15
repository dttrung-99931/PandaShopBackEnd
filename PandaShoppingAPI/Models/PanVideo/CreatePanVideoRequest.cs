using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PandaShoppingAPI.Models 
{
    public class CreatePanVideoRequest
    {
        [Required]
        public IFormFile video { get; set; }
        [Required]
        public IFormFile thumbnailImage { get; set; }
        public string description { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int durationInSecs { get; set; }
    }
}