using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaminrayApiExam.Core.DTOs;
using SaminrayApiExam.Core.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SaminrayApiExam.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCountController : ControllerBase
    {
        private readonly IProductService _poductService;
        public ProductCountController(IProductService productService)
        {
            _poductService = productService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetInventoryReport(bool sortByPrice = false)
        {
            var res = _poductService.GetProductCounts();
            if (sortByPrice)
            {
                var report = res.OrderBy(x => x.Price);
                var final = report.Select(p => new ProductCountDTO()
                {
                   Price = p.Price,
                   Name = p.Name,
                   ExpiryDate = p.ExpiryDate,
                   Group = p.Group,
                   ProductCount = p.ProductCount
                }).ToList();
                return Ok(final);
            }
            return Ok(res);
        }
    }
}
