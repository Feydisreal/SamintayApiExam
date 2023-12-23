using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.DTOs
{
  
    public class ReceiptDTO
    {
        public int ProductRef { get; set; }
        public int ProductCount { get; set; }
        public float ProductPrice { get; set; }
    }
    public class OrderDTO 
    {
        public int ProductRef { get; set; }
        public int ProductCount { get; set; }
        public float ProductPrice { get; set; }
    }
    public class OrderResponseDTO : Response
    {
        public string ProductName { get; set; } = null!;
        public int ProductCount { get; set; }
        public int OrderCount { get; set; }
        public float ProductPrice { get; set; }
        public float OrderPrice { get; set; }
    }
}
