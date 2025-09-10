using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardianController : ControllerBase
    {
        private readonly ILogger<GuardianController> _logger;

        public GuardianController(ILogger<GuardianController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Guardians")]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(new { Message = "Guardians endpoint is working!" });
        }

        [HttpGet("Guardian/{id}")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(new { Message = "Guardians endpoint is working!" });
        }

        [HttpPost("Guardian")]
        public async Task<IActionResult> CreateAsync()
        {
            return Ok(new { Message = "Create Guardians endpoint is working!" });
        }

        [HttpPut("Guardian")]
        public async Task<IActionResult> UpdateAsync()
        {
            return Ok(new { Message = "Update Guardians endpoint is working!" });
        }

        [HttpDelete("Guardian")]
        public async Task<IActionResult> DeleteAsync()
        {
            return Ok(new { Message = "Delete Guardians endpoint is working!" });
        }
    }
}
