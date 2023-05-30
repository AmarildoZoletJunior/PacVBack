using Booking.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.APIProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpPost("{roomId:int}")]
        public async Task<IActionResult> PostImage([FromForm]IFormFile file, int roomId)
        {
         var result = await imageService.PostImage(file, roomId);
            if (result.IsValid)
            {
                return NoContent();
            }
            return BadRequest(result.MessagesErrors);
        }

        [HttpPost("ImageMain/{roomId:int}")]
        public async Task<IActionResult> PostMainImage([FromForm]IFormFile file, int roomId)
        {
            var result = await imageService.UpdateOrPostMainImage(file, roomId);
            if (result.IsValid)
            {
                return NoContent();
            }
            return BadRequest(result.MessagesErrors);
        }
    }
}
