using FirstAPIApp.DTOs;
using FirstAPIApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FirstAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipTypesController : ControllerBase
    {
        private readonly IMembershipTypesService _membershipTypesService;
        private readonly ILogger<MembershipTypesController> _logger;

        public MembershipTypesController(IMembershipTypesService membershipTypesService, ILogger<MembershipTypesController> logger)
        {
            _membershipTypesService = membershipTypesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetMembershipTypes started");

                var membershipTypes = await _membershipTypesService.GetMembershipTypesAsync();

                if (membershipTypes == null || !membershipTypes.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, "No element");
                }

                return Ok(membershipTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllMembershipTypes error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
    }
}
