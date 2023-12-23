using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.DTOs
{
    public class ProductGroupDTO
    {
        public string Name { get; set; } = null!;
        public int? ParentGroup { get; set; }
        public int Code { get; set; }

    }
    public class ProductGroupsDTO 
    {
        public int ProductGroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public int? ParentGroup { get; set; }
        public int Code { get; set; }
        public List<ProductDTO> Products { get; set; } = null!;
    }
}
