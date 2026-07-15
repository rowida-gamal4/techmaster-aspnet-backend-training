using Microsoft.AspNetCore.Mvc;
using RefactoredApi.DTOs;
using RefactoredApi.Services;

namespace RefactoredApi.Controllers
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
            return Created("",new
            {
                Message = "Product created successfully.",
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
                    Message = "No products found.",
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
                    Message = $"Product with id {id} not found",
                });
            }
            return Ok(result);
        }

     
    }
}