using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Core.Services.Interfaces;
using SaminrayApiExam.Data.Context;
using SaminrayApiExam.Data.Entities.Orders;
using SaminrayApiExam.Data.Entities.Products;
using SaminrayApiExam.Data.Entities.Receipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly SaminrayExamContext _context;

        public ProductService(SaminrayExamContext context)
        {

            _context = context;

        }

        public Product AddProduct(ProductDTO product)
        {
            var res = new Product() {
                Name = product.Name,
                Price = product.Price,
                ProductGroupRef = product.ProductGroupId,
                ExpiryDate = product.ExpiryDate,
            };
            _context.Products.Add(res);
            _context.SaveChanges();
            return res;
        }
        public Response DeleteProduct(int id)
        {

            if (_context.Products.Any(p => p.ProductId == id))
            {
                var selected = _context.Products.FirstOrDefault(p => p.ProductId == id);
                _context.Products.Remove(selected);
                _context.SaveChanges();

                return new Response() {
                    Success = true,
                    Message = "successfully deleted"
                };
            } else {
                return new Response()
                {
                    Success = false,
                    Message = "Product Not Found"
                };
            }
        }
        public Product EditProduct(ProductDTO product, int id)
        {
            var selected = _context.Products.FirstOrDefault(p => p.ProductId == id);
            selected.ProductGroupRef = product.ProductGroupId;
            selected.Name = product.Name;
            selected.ExpiryDate = product.ExpiryDate;
            selected.Price = product.Price;
            _context.Update(selected);
            _context.SaveChanges();
            return selected;
        }
        public List<ProductsDTO> products()
        {
            var res = _context.Products
                .Include(x=> x.ProductGroup)
                .ToList();
            var final = new List<ProductsDTO>();
            foreach (var item in res)
            {
                var temp = new ProductsDTO();
                temp.ExpiryDate = item.ExpiryDate;
                temp.Price = item.Price;
                temp.ProductGroupRef = item.ProductGroupRef;
                temp.ProductGroupName = item.ProductGroup.Name;
                temp.ProductId = item.ProductId;
                temp.Name = item.Name;
                temp.Count = _context.Receipts.Where(x => x.ProductRef == item.ProductId)
                   .Select(x => x.ProductCount).Sum() - _context.Orders.Where(x => x.ProductRef == item.ProductId)
                   .Select(x => x.ProductCount).Sum();
                final.Add(temp);
            }
            return final;

        }
        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }
    

    
        public List<ProductCountDTO> GetProductCounts()
        {
            var result = new List<ProductCountDTO>();

            var products = _context.Products
                .Include(x => x.ProductGroup)
                .ToList();

            foreach (var item in products)
            {
                var temp = new ProductCountDTO() {
                  
                Price = item.Price,
                ExpiryDate = item.ExpiryDate,
                Group = item.ProductGroup.Name,
                Name = item.Name
                };
                temp.ProductCount = _context.Receipts.Where(x => x.ProductRef == item.ProductId)
                   .Select(x => x.ProductCount).Sum() - _context.Orders.Where(x => x.ProductRef == item.ProductId)
                   .Select(x => x.ProductCount).Sum();
                result.Add(temp);
            }
            return result;

        }

   
    }
}
