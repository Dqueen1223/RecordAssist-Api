using System.Collections.Generic;
using Catalyte.Apparel.Data.Model;
using System.Threading.Tasks;


namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product related service methods.
    /// </summary>
    public interface IProductProvider
    {
        Task<Product> GetProductByIdAsync(int productId);

        Task<IEnumerable<Product>> GetProductsAsync(string brand, string category, string color,
                                                    string demographic, string material,
                                                    decimal price, string type);

        

        Task<List<string>> GetAllUniqueProductCategoriesAsync();

        Task<List<string>> GetAllUniqueProductTypesAsync();
    }
}
