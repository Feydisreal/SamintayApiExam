using Microsoft.EntityFrameworkCore;
using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Core.Services.Interfaces;
using SaminrayApiExam.Data.Context;
using SaminrayApiExam.Data.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly SaminrayExamContext _context;
        public OrderService(SaminrayExamContext context)
        {
            _context = context;
        }

        public OrderResponseDTO AddOrder(OrderDTO order)
        {

            if (_context.Products.Any(x => x.ProductId == order.ProductRef))
            {

                var totalAmount = _context.Receipts.Where(x => x.ProductRef == order.ProductRef)
                    .Select(x => x.ProductCount).Sum() - _context.Orders.Where(x => x.ProductRef == order.ProductRef)
                    .Select(x => x.ProductCount).Sum();
                
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
                    var product = _context.Products.FirstOrDefault(x => x.ProductId == res.ProductRef);
                    return new OrderResponseDTO()
                    {
                        ProductName = product.Name,
                        OrderCount = order.ProductCount,
                        OrderPrice = order.ProductPrice,
                        ProductCount = totalAmount - order.ProductCount,
                        ProductPrice = product.Price,
                        Message = "",
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
    }
}
