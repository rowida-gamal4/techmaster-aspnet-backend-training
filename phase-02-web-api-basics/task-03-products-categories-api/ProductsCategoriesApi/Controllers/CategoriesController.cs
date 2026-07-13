using Microsoft.AspNetCore.Mvc;
using ProductsCategoriesApi.DTOs;
using ProductsCategoriesApi.Services;

namespace ProductsCategoriesApi.Controllers
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
            if (result is null)
            {
                return BadRequest(new
                {
                    Message = "Category name already exists."
                });
            }
            return Ok(new
            {
                Message = "Category created Successfully.",
                result
            });
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var result = categoryService.GetAllCategories();
            if (!result.Any())
            {
                return Ok(new
                {
                    Message = "No active categories found.",
                    Categories = result
                });
            }
            return Ok(result);
        }
    }
}