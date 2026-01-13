using avantech.OrderingSystem.Data.Model;
using avantech.OrderingSystem.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        [EndpointName("GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public IActionResult Products(long? productCategoryId)
        {
            var result = _productService.GetProducts(productCategoryId);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Insert a new product
        /// </summary>
        [HttpPost("insert")]
        [EndpointName("InsertProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        public IActionResult Insert([FromBody] Product product)
        {
            var createdProduct = _productService.InsertProduct(product);
            return CreatedAtAction(nameof(Products), new { productCategoryId = createdProduct.ProductCategoryId }, createdProduct);
        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        [HttpPut("update/{id}")]
        [EndpointName("UpdateProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            var updatedProduct = _productService.UpdateProduct(id, product);
            return updatedProduct != null ? Ok(updatedProduct) : NotFound();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        [HttpDelete("delete/{id}")]
        [EndpointName("DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var success = _productService.DeleteProduct(id);
            return success ? NoContent() : NotFound();
        }
    }
}
