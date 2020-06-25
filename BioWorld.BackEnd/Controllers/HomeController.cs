using System.Linq;
using BioWorld.Application;
using BioWorld.Application.Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ApiController
    {
        private readonly IApplicationDbContext _context;

        private readonly IBlogConfigService _blogConfigService;

        public HomeController(ILogger<ControllerBase> logger,
            IApplicationDbContext context,
            IBlogConfigService blogConfigService) : base(logger)
        {
            _context = context;
            _blogConfigService = blogConfigService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _blogConfigService.AdvancedSettings = _context.AdvancedSettings.FirstOrDefault();
            _blogConfigService.ContentSettings = _context.ContentSettings.FirstOrDefault();
            _blogConfigService.FeedSettings = _context.FeedSettings.FirstOrDefault();
            _blogConfigService.FriendLinksSettings = _context.FriendLinksSettings.FirstOrDefault();
            _blogConfigService.GeneralSettings = _context.GeneralSettings.FirstOrDefault();
            _blogConfigService.NotificationSettings = _context.NotificationSettings.FirstOrDefault();
            _blogConfigService.WatermarkSettings = _context.WatermarkSettings.FirstOrDefault();

            // Overwrite the app setting value
            if (_blogConfigService.GeneralSettings != null)
                AppSettings.Instance.TimeZoneUtcOffset = _blogConfigService.GeneralSettings.TimeZoneUtcOffset;

            if (_blogConfigService.ContentSettings != null)
                AppSettings.Instance.DisharmonyWords = _blogConfigService.ContentSettings.DisharmonyWords;

            return Ok("BioWorld Blog BackEnd Service started");
        }
    }
}