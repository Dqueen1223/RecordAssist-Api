using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product repository methods.
    /// </summary>
    public interface IProductRepository
    {
        Task<Product> NoTrackingGetProductByIdAsync(int productId);
        Task<Product> GetProductByIdAsync(int productId);
        Task<int> GetProductsCountAsync(Nullable<bool> active, List<string> brand, List<string> category,
                                                                 List<string> color, List<string> demographic, List<string> material,
                                                                 decimal minPrice, decimal maxPrice, List<string> type, int? range, int returnProducts);

        Task<IEnumerable<Product>> GetProductsAsync(Nullable<bool> active, List<string> brand, List<string> category,
                                                                 List<string> color, List<string> demographic, List<string> material,
                                                                 decimal minPrice, decimal maxPrice, List<string> type, int? range, int returnProducts);

        Task<Product> UpdateProductAsync(Product Product);

        Task<List<string>> GetAllUniqueProductCategoriesAsync();
        Task<List<string>> GetAllUniqueProductTypesAsync();

        Task<Product> CreateProductAsync(Product newProduct);

        Task<Product> DeleteProductByIdAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
