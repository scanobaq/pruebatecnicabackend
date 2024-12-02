
using AutoMapper;
using iasalesmk.application.DTOs;
using iasalesmk.domain.Entities;
using iasalesmk.infrastructure.Repositories;

namespace iasalesmk.application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    private async Task ValidateProduct(int id)
    {
        if (!await ProductExists(id))
            throw new KeyNotFoundException($"Product with id {id} not found");
    }

    private void ValidateProductDto(ProductDto productDto)
    {
        if (productDto == null)
            throw new ArgumentNullException(nameof(productDto));

        if (string.IsNullOrEmpty(productDto.Name))
            throw new ArgumentException("Product name is required");

        if (productDto.Price <= 0)
            throw new ArgumentException("Product price must be greater than zero");

        if (productDto.Stock < 0)
            throw new ArgumentException("Product stock cannot be negative");
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        try
        {
            var products = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving products", ex);
        }
    }

    public async Task<ProductDto> GetProductById(int id)
    {
        try
        {
            await ValidateProduct(id);
            var product = await _productRepository.GetProductById(id);
            return _mapper.Map<ProductDto>(product);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving product with id {id}", ex);
        }
    }

    public async Task AddProduct(ProductDto productDto)
    {
        try
        {
            ValidateProductDto(productDto);
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.AddProduct(productEntity);
            await Save();
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding product", ex);
        }
    }

    public async Task UpdateProduct(int id, ProductDto productDto)
    {
        try
        {
            await ValidateProduct(id);
            ValidateProductDto(productDto);
            var productEntity = _mapper.Map<Product>(productDto);
            productEntity.Id = id;
            await _productRepository.UpdateProduct(productEntity);
            await Save();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating product with id {id}", ex);
        }
    }

    public async Task DeleteProduct(int id)
    {
        try
        {
            await ValidateProduct(id);
            await _productRepository.DeleteProduct(id);
            await Save();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting product with id {id}", ex);
        }
    }

    public async Task<bool> ProductExists(int id)
    {
        try
        {
            return await _productRepository.ProductExists(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error checking if product exists with id {id}", ex);
        }
    }

    public async Task Save()
    {
        try
        {
            await _productRepository.Save();
        }
        catch (Exception ex)
        {
            throw new Exception("Error saving changes", ex);
        }
    }

}
