using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Core.Services.Interfaces;
using SaminrayApiExam.Data.Context;
using SaminrayApiExam.Data.Entities.Orders;
using SaminrayApiExam.Data.Entities.Receipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly SaminrayExamContext _context;
        public TransactionService(SaminrayExamContext context)
        {
            _context = context;
        }

        #region Receipt

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
        #endregion


        #region Order
        public OrderResponseDTO AddOrder(OrderDTO order)
        {
            if (_context.Products.Any(x=> x.ProductId == order.ProductRef))
            {
                var totalReceipts = _context.Receipts.Where(x => x.ProductRef == order.ProductRef).ToList();
                var totalOrders = _context.Orders.Where(x => x.ProductRef == order.ProductRef).ToList();
                int totalAmount = 0;
                
                foreach (var item in totalReceipts)
                {
                    totalAmount += item.ProductCount;
                }

                foreach (var item in totalOrders)
                {
                    totalAmount -= item.ProductCount;
                }

                if (totalAmount >= order.ProductCount)
                {
                    var res = new Order()
                    {
                        OrderDate = DateTime.Now,
                        ProductRef = order.ProductRef,
                        ProductCount = order.ProductCount,
                        ProductPrice = order.ProductPrice,
                    };
                    _context.Add(res);
                    _context.SaveChanges();

                    return new OrderResponseDTO()
                    {
                        ProductName = _context.Products.FirstOrDefault(x => x.ProductId == res.ProductRef).Name,
                        OrderCount = order.ProductCount,
                        OrderPrice = order.ProductPrice,
                        ProductCount = totalAmount - order.ProductCount,
                        ProductPrice = _context.Products.FirstOrDefault(x=> x.ProductId == res.ProductRef).Price,
                        Message= "",
                        Success = true,

                    };
                }

                return new OrderResponseDTO()
                {
                    Message = "Not enough inventory in stock",
                    Success = false
                };



            }
            return new OrderResponseDTO()
            {
                Message = "Product Not Found",
                Success = false
            };

        }
        #endregion



    }
}
