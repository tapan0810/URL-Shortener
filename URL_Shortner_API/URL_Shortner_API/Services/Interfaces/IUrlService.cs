using URL_Shortner_API.DTOs;

namespace URL_Shortner_API.Services.Interfaces
{
    public interface IUrlService
    {
        Task<ShortUrlResponse> CreateShortUrlAsync(string originalUrl);
        Task<string?> GetOriginalUrlAsync(string shortCode);
        Task<ShortUrlResponse?> GetAnalyticsAsync(string shortCode);
    }
}
