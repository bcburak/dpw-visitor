using DpWorld.Visitor.Application.Interfaces;
using DpWorld.Visitor.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DpWorld.Visitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly IVisitorService _visitorService;

        public TeamsController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetTeams()
        {
            return Ok(_visitorService.GetTeams());
        }

    }
}
