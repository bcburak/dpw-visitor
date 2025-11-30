using DpWorld.Visitor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DpWorld.Visitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInController : ControllerBase
    {
        private readonly IVisitorService _visitorService;

        public CheckInController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpPost]
        public ActionResult<DpWorld.Visitor.Domain.Entities.Visitor> CheckIn([FromBody] CheckInRequest request)
        {
            try
            {
                var visitor = _visitorService.CheckIn(
                    request.Name,
                    request.Email,
                    request.Company,
                    request.TeamId,
                    request.EntranceId,
                    request.RulesAccepted
                );
                return Ok(visitor);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class CheckInRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public int TeamId { get; set; }
        public string EntranceId { get; set; } = string.Empty;
        public bool RulesAccepted { get; set; }
    }
}
