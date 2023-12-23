using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.Services.Interfaces
{
    public interface IProductGroupService
    {
        ProductGroup AddProductGroup(ProductGroupDTO group);
        List<ProductGroupsDTO> GetProductGroups();
        ProductGroup GetProductGroupById(int id);
        ProductGroup EditProductGroup(ProductGroupDTO group, int id);
        Response DeleteProductGroup(int id);
        bool CheckIfGroupIdExistById(int id);
    }
}
