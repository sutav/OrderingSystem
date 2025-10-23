using avantech.OrderingSystem.Data.Model;
using avantech.OrderingSystem.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace avantech.OrderingsSystem.Api
{
    
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]   
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get products
        /// </summary>
        /// <param name="productCategoryId" >product Category Id</param>
        /// <response code="200">Products</response>        
        [HttpGet("products")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public IActionResult Products(long? productCategoryId)
        {
            var result = _productService.GetProducts(productCategoryId);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
