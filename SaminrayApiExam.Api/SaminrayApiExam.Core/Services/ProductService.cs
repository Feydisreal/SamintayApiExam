using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Core.Services.Interfaces;
using SaminrayApiExam.Data.Context;
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

        #region Product

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
                .Include(x=> x.Orders)
                .Include(x=> x.Receipts)
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
                var receipts = _context.Receipts.Where(x => x.ProductRef == item.ProductId).ToList();
                var orders = _context.Orders.Where(x => x.ProductRef == item.ProductId).ToList();
                int total = 0;
                if (receipts != null)
                {
                    foreach (var rec in receipts)
                    {
                        total += rec.ProductCount;
                    }
                }
                if (orders != null)
                {
                    foreach (var order in orders)
                    {
                        total -= order.ProductCount;
                    }
                }
                temp.Count = total;

                final.Add(temp);
            }
            return final;

        }
        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }
        #endregion

        #region ProductGroup

        public ProductGroup AddProductGroup(ProductGroupDTO group)
        {
            var res = new ProductGroup()
            {
                Code = group.Code,
                Name = group.Name,
                ParentGroup = group.ParentGroup,
            };
            _context.Add(res);
            _context.SaveChanges();
            return res;
        }

       

        public ProductGroup GetProductGroupById(int id)
        {
            return _context.ProductGroups.FirstOrDefault(x => x.ProductGroupId == id);
        } 


        public ProductGroup EditProductGroup(ProductGroupDTO group, int id)
        {
            var selected = _context.ProductGroups.FirstOrDefault(p => p.ProductGroupId == id);
            selected.ParentGroup = group.ParentGroup;
            selected.Code = group.Code;
            selected.Name = group.Name; 
            _context.Update(selected);
            _context.SaveChanges();
            return selected;
        }


        public Response DeleteProductGroup(int id)
        {
            if (_context.ProductGroups.Any(x => x.ProductGroupId == id))
            {
                var selected = _context.ProductGroups.FirstOrDefault(x => x.ProductGroupId == id);
                _context.ProductGroups.Remove(selected);
                _context.SaveChanges();

                return new Response()
                {
                    Success = true,
                    Message = "successfully deleted"
                };
            }
            else
            {
                return new Response()
                {
                    Success = false,
                    Message = "Product Group Not Found"
                };
            }
        }
        #endregion
        public List<ProductCountDTO> GetProductCounts()
        {
            var result = new List<ProductCountDTO>();

            var products = _context.Products
                .Include(x => x.ProductGroup)
                .Include(x => x.Receipts)
                .Include(x=> x.Orders)
                .ToList();

            foreach (var item in products)
            {
                var temp = new ProductCountDTO() {
                  
                Price = item.Price,
                ExpiryDate = item.ExpiryDate,
                Group = item.ProductGroup.Name,
                Name = item.Name
                };
                var receipts = _context.Receipts.Where(x => x.ProductRef == item.ProductId).ToList();
                var orders = _context.Orders.Where(x => x.ProductRef == item.ProductId).ToList();
                int final = 0;
                if (receipts != null)
                {
                    foreach (var rec in receipts)
                    {
                        final += rec.ProductCount;
                    }
                }
                if (orders != null)
                {
                    foreach (var order in orders)
                    {
                        final -= order.ProductCount;
                    }
                }
               
                temp.ProductCount = final;
                result.Add(temp);
            }
            return result;

        }

        public List<ProductGroupsDTO> GetProductGroups()
        {
            var test = _context.ProductGroups
             .Include(x => x.Products)
             .ToList();

            var final = new List<ProductGroupsDTO>();

            foreach (var item in test)
            {
                var temp = new ProductGroupsDTO()
                {
                    ParentGroup = item.ParentGroup,
                    Code = item.Code,
                    GroupName = item.Name,
                    ProductGroupId = item.ProductGroupId,
                };
                var products = _context.Products.Where(x=> x.ProductGroupRef == temp.ProductGroupId).ToList();
                var productTemp = new List<ProductDTO>();
                foreach (var item1 in products)
                {
                    var t = new ProductDTO()
                    {
                        ExpiryDate = item1.ExpiryDate,
                        Name = item1.Name,
                        Price = item1.Price,
                        ProductGroupId = item1.ProductGroupRef
                    };
                    productTemp.Add(t);
                }
                temp.Products = productTemp;
                final.Add(temp);
            }
            return final;

        }
    }
}
