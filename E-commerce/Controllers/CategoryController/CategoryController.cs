using Dtos.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CategoryServices;

namespace E_commerce.Controllers.CategoryController
{
    [ApiController] 
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        [HttpGet] 
        public async Task<ActionResult<List<CategoryDTO>>> GetAllCategorys()
        {
            var Categorys = await _CategoryService.GetAllAsync();
            if (Categorys == null)
            {
                return Ok(new List<CategoryDTO>());
            }
            return Ok(Categorys);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var Category = await _CategoryService.GetByIdAsync(id);
            if (Category == null)
            {
                return NotFound();
            }
            return Ok(Category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryDTO CategoryDTO)
        {
            var createdCategory = await _CategoryService.CreateAsync(CategoryDTO);

            return Ok(createdCategory);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, CategoryDTO CategoryDTO)
        {
            var existingDto = await _CategoryService.GetByIdAsync(id);
            if (existingDto == null)
            {
                return NotFound();
            }
            await _CategoryService.UpdateAsync(CategoryDTO);
            return Ok("Updated Successfuly");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _CategoryService.DeleteAsync(id);
            return Ok("Deleted Successfuly");
        }
    }
}
