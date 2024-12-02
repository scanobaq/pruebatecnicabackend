using iasalesmk.application.DTOs;
using iasalesmk.application.Services;
using Microsoft.AspNetCore.Mvc;

namespace iasalesmk.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{

    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _categoryService.GetCategoryById(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryDto categoryDto)
    {
        var category = await _categoryService.CreateCategory(categoryDto);
        return Ok(category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
    {
        await _categoryService.UpdateCategory(id, categoryDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategory(id);
        return NoContent();
    }


}
