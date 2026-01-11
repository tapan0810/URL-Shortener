using System.ComponentModel.DataAnnotations;

namespace URL_Shortner_API.Models
{
    public class ShortUrl
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(2048)]
        public string OriginalUrl {  get; set; }=string.Empty;
        [Required]
        [MaxLength(10)]
        public string ShortCode { get; set; } = string.Empty;
        public int ClickCount {  get; set; } = 0;
        public DateTime CreateAt {  get; set; } = DateTime.UtcNow;
        public DateTime? ExpiryDate {  get; set; }
        public bool IsActive {  get; set; } = true;
    }
}
