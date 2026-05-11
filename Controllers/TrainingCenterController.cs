using Microsoft.AspNetCore.Mvc;
using TrainingCenterRegistry.Models;
using TrainingCenterRegistry.Services;

namespace TrainingCenterRegistry.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingCenterController : ControllerBase
    {
        private readonly ITrainingCenterService _service;

        public TrainingCenterController(
            ITrainingCenterService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingCenter(
            [FromBody] TrainingCenter center)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response =
                await _service.AddTrainingCenterAsync(center);

            return Created("", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainingCenters(
            [FromQuery] string? city)
        {
            var data =
                await _service.GetTrainingCentersAsync(city);

            return Ok(data);
        }
    }
}
