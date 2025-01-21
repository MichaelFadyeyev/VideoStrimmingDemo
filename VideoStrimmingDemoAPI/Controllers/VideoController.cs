using Microsoft.AspNetCore.Mvc;


namespace VideoStrimmingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
        
        [HttpGet("{fileName}")]
        public IActionResult GetVideo(string fileName)
        {
            var currentDir = Directory.GetCurrentDirectory(); 
            var filePath = Path.Combine("Videos", fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }
            return PhysicalFile(filePath, "video/mp4", enableRangeProcessing: true);
        }
    }
}
