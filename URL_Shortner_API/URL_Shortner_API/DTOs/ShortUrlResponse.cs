namespace URL_Shortner_API.DTOs
{
    public class ShortUrlResponse
    {
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        public int ClickCount { get; set; }
    }
}
