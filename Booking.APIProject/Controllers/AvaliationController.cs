using AutoMapper;
using Booking.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.APIProject.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AvaliationController : ControllerBase
    {
        private readonly IAvaliationService _avaliationService;
        private readonly IMapper _mapper;

        public AvaliationController(IAvaliationService avaliationService, IMapper mapper)
        {
            _avaliationService = avaliationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAvaliation()
        {
            return Ok();
        }
    }
}
