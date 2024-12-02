using iasalesmk.application.DTOs;
using iasalesmk.application.Services;
using Microsoft.AspNetCore.Mvc;

namespace iasalesmk.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            await _productService.AddProduct(productDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            await _productService.UpdateProduct(id, productDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }


    }
}