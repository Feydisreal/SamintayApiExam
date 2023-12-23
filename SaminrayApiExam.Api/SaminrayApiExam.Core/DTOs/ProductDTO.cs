using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; } = null!;
        public int ProductGroupId { get; set; }
        public float Price { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
    public class ProductsDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public int ProductGroupRef { get; set; }
        public string ProductGroupName { get; set; } = null!;
        public int Count { get; set; }
        public float Price { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
    public class ProductCountDTO
    {
        public string Name { get; set; } = null!;
        public int ProductCount { get; set; }
        public string Group { get; set; } = null!;
        public float Price { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

}
