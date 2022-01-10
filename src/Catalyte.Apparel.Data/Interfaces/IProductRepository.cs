using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product repository methods.
    /// </summary>
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int productId);

        Task<IEnumerable<Product>> GetProductsAsync(string brand, string category, string color,
                                                    string demographic, string material,
                                                    decimal price, string type);


        Task<List<string>> GetAllUniqueProductCategoriesAsync();

        Task<List<string>> GetAllUniqueProductTypesAsync();

    }
}
