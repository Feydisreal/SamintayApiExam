using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Core.Services.Interfaces;

namespace SaminrayApiExam.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductService _poductService;
        public ProductGroupController(IProductService productService)
        {
            _poductService = productService;
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddProductGroup([FromBody] ProductGroupDTO group)
        {

            return Ok(_poductService.AddProductGroup(group));
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetProductGroups()
        {
            return Ok(_poductService.GetProductGroups());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetProductGroupById(int id)
        {
            return Ok(_poductService.GetProductGroupById(id));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult EditProductGroupById(int id, [FromBody] ProductGroupDTO group)
        {
            return Ok(_poductService.EditProductGroup(group, id));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteProductGroupById(int id)
        {
            return Ok(_poductService.DeleteProductGroup(id));
        }
    }
}
