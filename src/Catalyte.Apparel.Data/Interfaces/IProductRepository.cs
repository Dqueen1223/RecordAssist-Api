using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product repository methods.
    /// </summary>
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int productId);

        Task<IEnumerable<Product>> GetProductsAsync();

        Task<IEnumerable<Product>> GetProductsByBrandAsync(string productBrand);

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string productCategory);

        Task<IEnumerable<Product>> GetProductsByColorAsync(string productColor);

        Task<IEnumerable<Product>> GetProductsByDemographicAsync(string productDemographic);

        Task<IEnumerable<Product>> GetProductsByMaterialAsync(string productMaterial);

        Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal productPrice);

        Task<IEnumerable<Product>> GetProductsByTypeAsync(string productType);

    }
}
