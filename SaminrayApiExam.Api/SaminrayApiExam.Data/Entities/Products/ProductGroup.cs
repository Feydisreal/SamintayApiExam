using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SaminrayApiExam.Data.Entities.Products
{
    public class ProductGroup
    {
        [Key]
        public int ProductGroupId { get; set; }
        public string Name { get; set; } = null!;
        public int? ParentGroup { get; set; }
        public int Code { get; set; }

        [InverseProperty("ProductGroup")]
        [JsonIgnore]
        public virtual List<Product> Products { get; set; } = null!;
    }
}
