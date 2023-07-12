using AutoMapper;
using Booking.Application.DTOs.PaymentDTO;
using Booking.Application.Interfaces;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Booking.APIProject.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePayment([Required] PaymentRequest payment)
        {
            var paymentMap = _mapper.Map<Payment>(payment);
            var result = await _paymentService.CreatePayment(paymentMap);
            if (result.IsValid)
            {
                return NoContent();
            }
            return BadRequest(result.MessagesErrors);
        }
        [Authorize]
        [HttpGet("{ClienteId:int}")]
        public async Task<IActionResult> GetAllPaymentsByClientId([Required] int ClientId)
        {
            var Payments = await _paymentService.GetPaymentById(ClientId);
            if (Payments.IsValid)
            {
                return Ok(Payments.Data);
            }
            return BadRequest(Payments.MessagesErrors);
        }
        [Authorize]
        [HttpGet("{paymentId:int}")]
        public async Task<IActionResult> GetPaymentById([Required] int paymentId)
        {
            var Payments = await _paymentService.GetPaymentById(paymentId);
            if (Payments.IsValid)
            {
                return Ok(Payments.Data);
            }
            return BadRequest(Payments.MessagesErrors);
        }
        [Authorize]
        [HttpGet("{roomId:int}")]
        public async Task<IActionResult> GetPaymentByRoomId([Required] int roomId)
        {
            var Payments = await _paymentService.GetAllPaymentsByRoomId(roomId);
            if (Payments.IsValid)
            {
                return Ok(Payments.Data);
            }
            return BadRequest(Payments.MessagesErrors);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var Payments = await _paymentService.GetAllPayment();
            if (Payments.IsValid)
            {
                return Ok(Payments.Data);
            }
            return BadRequest(Payments.MessagesErrors);
        }
        [Authorize]
        [HttpPut("{paymentId:int}")]
        public async Task<IActionResult> PutStatusForPay([Required] int paymentId)
        {
            var Payments = await _paymentService.PutStatusForPay(paymentId);
            if (Payments.IsValid)
            {
                return Ok(Payments.Data);
            }
            return BadRequest(Payments.MessagesErrors);
        }
        [Authorize]
        [HttpPut("{paymentID:int}")]
        public async Task<IActionResult> PutStatusForCancel([Required] int paymentID)
        {
            var Payments = await _paymentService.PutStatusForPay(paymentID);
            if (Payments.IsValid)
            {
                return Ok(Payments.Data);
            }
            return BadRequest(Payments.MessagesErrors);
        }
    }
}
