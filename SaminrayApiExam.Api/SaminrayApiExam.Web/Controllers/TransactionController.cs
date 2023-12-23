using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Core.Services;
using SaminrayApiExam.Core.Services.Interfaces;

namespace SaminrayApiExam.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly IReceiptService _receiptService;
        public TransactionController( IOrderService orderService , IReceiptService receiptService)
        {
            _orderService = orderService;
            _receiptService = receiptService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddReceipt([FromBody] ReceiptDTO receipt)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_receiptService.AddReceipt(receipt));
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderDTO order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_orderService.AddOrder(order));
        }
    }
}
