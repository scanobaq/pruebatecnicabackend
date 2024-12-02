using iasalesmk.domain.Entities;

namespace iasalesmk.infrastructure.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategoryById(int id);
    Task AddCategory(Category category);
    Task UpdateCategory(Category category);
    Task DeleteCategory(Category category);
    Task<bool> CategoryExists(int id);
    Task Save();
}
