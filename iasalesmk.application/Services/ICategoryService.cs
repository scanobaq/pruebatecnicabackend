using iasalesmk.application.DTOs;

namespace iasalesmk.application.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetCategories();
    Task<CategoryDto> GetCategoryById(int id);
    Task<CategoryDto> CreateCategory(CategoryDto categoryDto);
    Task UpdateCategory(int id, CategoryDto categoryDto);
    Task DeleteCategory(int id);
    Task Save();
}
