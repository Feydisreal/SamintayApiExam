using Microsoft.EntityFrameworkCore;
using SaminrayApiExam.Data.Entities.Orders;
using SaminrayApiExam.Data.Entities.Products;
using SaminrayApiExam.Data.Entities.Receipts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Data.Context
{
    public class SaminrayExamContext : DbContext
    {
        public SaminrayExamContext(DbContextOptions<SaminrayExamContext> options)
            :base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductGroup> ProductGroups { get; set; } = null!;
        public DbSet<Receipt> Receipts { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;




    }
}
