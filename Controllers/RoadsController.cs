namespace Gis.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    
    [ApiController]
    [Route("[controller]")]
    public class RoadsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoadsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAllRoads()
        {
            var query = new GetAllRoadsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getByArea")]
        public async Task<IActionResult> GetRoadsByArea(double x1, double y1, double x2, double y2)
        {
            var query = new GetRoadsByAreaQuery(x1, y1, x2, y2);
            var result = await _mediator.Send(query);

            return result != null ?
                (IActionResult) Ok(result) : NotFound();
        }
    }
}