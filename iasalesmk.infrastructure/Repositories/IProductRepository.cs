using iasalesmk.domain.Entities;

namespace iasalesmk.infrastructure.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProductById(int id);
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(int id);
    Task<bool> ProductExists(int id);
    Task Save();
}
