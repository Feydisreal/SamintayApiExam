using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Core.Services.Interfaces;
using SaminrayApiExam.Data.Entities.Products;

namespace SaminrayApiExam.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _poductService;
        public ProductController(IProductService productService)
        {
            _poductService = productService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDTO product)
        {

            return Ok(_poductService.AddProduct(product));
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_poductService.products());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_poductService.GetProductById(id));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult EditProductById(int id, [FromBody] ProductDTO product)
        {
            return Ok(_poductService.EditProduct(product, id));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(int id)
        {
            return Ok(_poductService.DeleteProduct(id));
        }
       
    }
}

