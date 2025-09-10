using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Students")]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(new { Message = "Students endpoint is working!" });
        }

        [HttpGet("Student/{id}")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(new { Message = "Student endpoint is working!" });
        }

        [HttpPost("Student")]
        public async Task<IActionResult> CreateAsync()
        {
            return Ok(new { Message = "Create Student endpoint is working!" });
        }

        [HttpPut("Student")]
        public async Task<IActionResult> UpdateAsync()
        {
            return Ok(new { Message = "Update Student endpoint is working!" });
        }

        [HttpDelete("Student")]
        public async Task<IActionResult> DeleteAsync()
        {
            return Ok(new { Message = "Delete Student endpoint is working!" });
        }
    }
}
