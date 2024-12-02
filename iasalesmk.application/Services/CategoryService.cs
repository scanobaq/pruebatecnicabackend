using AutoMapper;
using iasalesmk.application.DTOs;
using iasalesmk.domain.Entities;
using iasalesmk.infrastructure.Repositories;

namespace iasalesmk.application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    private async Task ValidateCategory(int id)
    {
        if (!await _categoryRepository.CategoryExists(id))
            throw new KeyNotFoundException($"Category with id {id} not found");
    }

    private void ValidateCategory(CategoryDto categoryDto)
    {
        if (categoryDto == null)
            throw new ArgumentNullException(nameof(categoryDto));
    }

    private void ValidateCategoryDto(CategoryDto categoryDto)
    {
        if (string.IsNullOrEmpty(categoryDto.Name))
            throw new ArgumentException("Category name is required");

        if (string.IsNullOrEmpty(categoryDto.Description))
            throw new ArgumentException("Category description is required");
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        try
        {
            var categories = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
        catch (System.Exception ex)
        {
            throw new Exception("Error retrieving categories", ex);
        }
    }

    public async Task<CategoryDto> GetCategoryById(int id)
    {
        try
        {
            await ValidateCategory(id);
            var category = await _categoryRepository.GetCategoryById(id);
            return _mapper.Map<CategoryDto>(category);
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Error retrieving category with id {id}", ex);
        }
    }

    public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto)
    {
        try
        {
            ValidateCategoryDto(categoryDto);
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddCategory(category);
            await Save();
            return _mapper.Map<CategoryDto>(category);

        }
        catch (System.Exception ex)
        {
            throw new Exception("Error creating category", ex);
        }
    }

    public async Task UpdateCategory(int id, CategoryDto categoryDto)
    {
        try
        {
            await ValidateCategory(id);
            ValidateCategoryDto(categoryDto);
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateCategory(category);
            await Save();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Error updating category with id {id}", ex);
        }
    }

    public async Task DeleteCategory(int id)
    {
        try
        {
            await ValidateCategory(id);
            var category = await _categoryRepository.GetCategoryById(id);
            await _categoryRepository.DeleteCategory(category);
            await Save();
        }
        catch (System.Exception ex)
        {
            throw new Exception($"Error deleting category with id {id}", ex);
        }
    }

    public async Task Save()
    {
        await _categoryRepository.Save();
    }
}
