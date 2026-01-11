using Microsoft.AspNetCore.Mvc;
using URL_Shortner_API.DTOs;
using URL_Shortner_API.Services.Interfaces;

namespace URL_Shortner_API.Controllers
{
    [ApiController]
    [Route("api/urls")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShortUrl(CreateShortUrlRequest request)
        {
            var result = await _urlService.CreateShortUrlAsync(request.OriginalUrl);
            return Ok(result);
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> GetAnalytics(string shortCode)
        {
            var result = await _urlService.GetAnalyticsAsync(shortCode);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
