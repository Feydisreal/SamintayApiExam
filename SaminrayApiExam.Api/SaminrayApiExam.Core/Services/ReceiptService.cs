using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Core.Services.Interfaces;
using SaminrayApiExam.Data.Context;
using SaminrayApiExam.Data.Entities.Receipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly SaminrayExamContext _context;
        public ReceiptService(SaminrayExamContext context)
        {
            _context = context;
        }

        public Receipt AddReceipt(ReceiptDTO receipt)
        {
            var res = new Receipt()
            {
                ProductCount = receipt.ProductCount,
                ProductPrice = receipt.ProductPrice,
                ProductRef = receipt.ProductRef,
                ReceiptDate = DateTime.Now,
                TotalPrice = receipt.ProductPrice * receipt.ProductCount
            };
            _context.Add(res);
            _context.SaveChanges();
            return res;
        }
    }
}
