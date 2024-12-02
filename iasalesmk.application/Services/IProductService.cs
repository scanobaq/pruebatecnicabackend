
using iasalesmk.application.DTOs;

namespace iasalesmk.application.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetProductById(int id);
    Task AddProduct(ProductDto productDto);
    Task UpdateProduct(int id, ProductDto productDto);
    Task DeleteProduct(int id);
    Task<bool> ProductExists(int id);
    Task Save();
}
