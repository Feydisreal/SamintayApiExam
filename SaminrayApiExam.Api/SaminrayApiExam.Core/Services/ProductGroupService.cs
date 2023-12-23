using Microsoft.EntityFrameworkCore;
using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Core.Services.Interfaces;
using SaminrayApiExam.Data.Context;
using SaminrayApiExam.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.Services
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly SaminrayExamContext _context;
        public ProductGroupService(SaminrayExamContext context)
        {
            _context = context;

        }

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
        public List<ProductGroupsDTO> GetProductGroups()
        {
            var productGroups = _context.ProductGroups.ToList();

            var result = new List<ProductGroupsDTO>();

            foreach (var item in productGroups)
            {
                var temp = new ProductGroupsDTO()
                {
                    ParentGroup = item.ParentGroup,
                    Code = item.Code,
                    GroupName = item.Name,
                    ProductGroupId = item.ProductGroupId,
                };
                var products = _context.Products.Where(x => x.ProductGroupRef == temp.ProductGroupId).ToList();
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
                result.Add(temp);
            }
            return result;

        }

        public bool CheckIfGroupIdExistById(int id)
        {
            return _context.ProductGroups.Any(x => x.ProductGroupId == id);
        }
    }
}
