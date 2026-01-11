using Microsoft.EntityFrameworkCore;
using URL_Shortner_API.Data;
using URL_Shortner_API.DTOs;
using URL_Shortner_API.Helpers;
using URL_Shortner_API.Models;
using URL_Shortner_API.Services.Interfaces;

namespace URL_Shortner_API.Services
{
    public class UrlService : IUrlService
    {
        private readonly UrlShortenerDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrlService(
            UrlShortenerDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ShortUrlResponse> CreateShortUrlAsync(string originalUrl)
        {
            string shortCode;
            do
            {
                shortCode = ShortCodeGenerator.Generate();
            }
            while (await _context.ShortUrls.AnyAsync(x => x.ShortCode == shortCode));

            var shortUrl = new ShortUrl
            {
                OriginalUrl = originalUrl,
                ShortCode = shortCode
            };

            _context.ShortUrls.Add(shortUrl);
            await _context.SaveChangesAsync();

            var request = _httpContextAccessor.HttpContext!.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";

            return new ShortUrlResponse
            {
                OriginalUrl = originalUrl,
                ShortUrl = $"{baseUrl}/{shortCode}",
                ClickCount = 0
            };
        }

        public async Task<string?> GetOriginalUrlAsync(string shortCode)
        {
            var entity = await _context.ShortUrls
                .FirstOrDefaultAsync(x => x.ShortCode == shortCode && x.IsActive);

            if (entity == null)
                return null;

            entity.ClickCount++;
            await _context.SaveChangesAsync();

            return entity.OriginalUrl;
        }

        public async Task<ShortUrlResponse?> GetAnalyticsAsync(string shortCode)
        {
            var entity = await _context.ShortUrls
                .FirstOrDefaultAsync(x => x.ShortCode == shortCode);

            if (entity == null)
                return null;

            return new ShortUrlResponse
            {
                OriginalUrl = entity.OriginalUrl,
                ShortUrl = entity.ShortCode,
                ClickCount = entity.ClickCount
            };
        }
    }
}
