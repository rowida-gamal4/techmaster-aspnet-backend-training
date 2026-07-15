using BookStoreApi.DTOs;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryRequest categoryRequest)
        {
            var result = categoryService.CreateCategory(categoryRequest);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Created("", result);
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var result = categoryService.GetAllCategories();
           
            return Ok(result);
        }
    }
}