using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.Services.Interfaces
{
    public interface IProductService
    {
        #region Product
        Product AddProduct(ProductDTO product);
        List<ProductsDTO> products();
        Product GetProductById(int id);
        Product EditProduct(ProductDTO product, int id);
        Response DeleteProduct(int id);
        #endregion


        #region Product Count
        List<ProductCountDTO> GetProductCounts();
        #endregion
    }
}
