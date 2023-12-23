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
        private readonly IProductGroupService _groupService;
        public ProductGroupController(IProductGroupService group)
        {
            _groupService = group;
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddProductGroup([FromBody] ProductGroupDTO group)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_groupService.AddProductGroup(group));
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetProductGroups()
        {
            return Ok(_groupService.GetProductGroups());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetProductGroupById(int id)
        {
           
            return Ok(_groupService.GetProductGroupById(id));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult EditProductGroupById(int id, [FromBody] ProductGroupDTO group)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_groupService.EditProductGroup(group, id));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteProductGroupById(int id)
        {
           
            return Ok(_groupService.DeleteProductGroup(id));
        }
    }
}
