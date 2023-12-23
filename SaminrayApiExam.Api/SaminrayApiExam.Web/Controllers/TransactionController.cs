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

        private readonly ITransactionService _transactionService;
        public TransactionController( ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddReceipt([FromBody] ReceiptDTO receipt)
        {

            return Ok(_transactionService.AddReceipt(receipt));
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderDTO order)
        {

            return Ok(_transactionService.AddOrder(order));
        }
    }
}
