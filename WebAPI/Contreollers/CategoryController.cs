using Application.Dto.Category;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Contreollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [SwaggerOperation(Summary = "get all categories")]
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public IActionResult Create(CreateCategoryDto newCategory)
        {
            var category =_categoryService.AddNewCategory(newCategory);
            return Created($"api/Categories/{category.Id}", category);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCategoryDto updated)
        {
            _categoryService.UpdateCategory(id, updated);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }


    }

}
