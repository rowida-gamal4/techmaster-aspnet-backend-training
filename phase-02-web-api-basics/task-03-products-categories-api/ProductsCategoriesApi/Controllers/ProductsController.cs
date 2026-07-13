using Microsoft.AspNetCore.Mvc;
using ProductsCategoriesApi.DTOs;
using ProductsCategoriesApi.Services;

namespace ProductsCategoriesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody]CreateProductRequest productRequest)
        {
            var result = productService.CreateProduct(productRequest);
            if (result is null)
            {
                return BadRequest(new
                {
                    Message = "Category does not exist"
                });
            }
            return Ok(new
            {
                Message = "Product created Successfully.",
                result
            });
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var result = productService.GetAllProducts();
            if (!result.Any())
            {
                return Ok(new
                {
                    Message = "No available products found.",
                    Products = result
                });
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var result = productService.GetProductById(id);
            if (result is null)
            {
                return NotFound(new
                {
                    Message = "Product id not found",
                });
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id,[FromBody] UpdateProductRequest request)
        {
            var result = productService.UpdateProduct(id,request);
            if (result is null)
            {
                return NotFound(new
                {
                    Message = "Product not found or category does not exist."
                });
            }
            return Ok(result);
        }

        [HttpPatch("{id}/stock")]
        public IActionResult UpdateProductStock(int id,[FromBody] UpdateStockRequest request)
        {
            var result = productService.UpdateProductStock(id,request);
            if (result is null)
            {
                return NotFound(new
                {
                    Message = "Invalid id",
                });
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = productService.DeleteProduct(id);
            if (result is null)
            {
                return NotFound(new
                {
                    Message = "Invalid id",
                });
            }
            return Ok(new
            {
                Message = "Product Deleted Successfully"
            });
        }

        [HttpGet("filter")]
        public IActionResult GetProductsWithFilter([FromQuery] Filter filter)
        {
            var result = productService.GetProductsWithFilterAndSearch(filter);
            if (!result.Any())
            {
                return Ok(new
                {
                    Message = "No products found.",
                    Products = result
                });
            }
            return Ok(result);
        }

        [HttpGet("reports/stock-value")]
        public IActionResult GetStockReports()
        {
            var result = productService.StockReports();
            return Ok(result);
        }
    }
}