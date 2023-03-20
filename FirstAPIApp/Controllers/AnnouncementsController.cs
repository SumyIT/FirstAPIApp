using FirstAPIApp.DTOs;
using FirstAPIApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FirstAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsService _announcementsService;
        private readonly ILogger<AnnouncementsController> _logger;

        public AnnouncementsController(IAnnouncementsService announcementsService, ILogger<AnnouncementsController> logger)
        {
            _announcementsService = announcementsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAnnouncements started");

                var announcements = await _announcementsService.GetAnnouncementsAsync();

                if (announcements == null || !announcements.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, "No element");
                }

                return Ok(announcements);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllAnnouncements error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
    }
}
