using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Data.Entities.Orders;
using SaminrayApiExam.Data.Entities.Receipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.Services.Interfaces
{
    public interface ITransactionService
    {
        Receipt AddReceipt(ReceiptDTO receipt);
        OrderResponseDTO AddOrder(OrderDTO order);
    }
}
