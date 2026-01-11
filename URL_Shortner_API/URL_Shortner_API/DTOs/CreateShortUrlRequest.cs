using System.ComponentModel.DataAnnotations;

namespace URL_Shortner_API.DTOs
{
    public class CreateShortUrlRequest
    {
        [Required]
        [Url]
        public string OriginalUrl { get; set; } = string.Empty;
    }
}
