using CachingWithRepositoryPattern.Business.Services.Products;
using CachingWithRepositoryPattern.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CachingWithRepositoryPattern.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {           
            return Ok(_productService.GetAll());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(string name)
        {
            Product product = new();
            product.Name = name;

            await _productService.AddAsync(product);
            return NoContent();
        }
    }
}
