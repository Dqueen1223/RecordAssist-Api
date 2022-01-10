using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the product repository.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly IApparelCtx _ctx;

        public ProductRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _ctx.Products.FindAsync(productId);
        }

        public async Task<List<string>> GetAllUniqueProductCategoriesAsync()
        {
            return await _ctx.Products.Select(l => l.Category).Distinct().ToListAsync();
        }

        public async Task<List<string>> GetAllUniqueProductTypesAsync()
        {
            return await _ctx.Products.Select(l => l.Type).Distinct().ToListAsync();
        }


        public async Task<IEnumerable<Product>> GetProductsAsync(string brand, string category, string color, 
                                                                 string demographic, string material, 
                                                                 decimal price, string type)
        {
            return await _ctx.Products.Where(p =>
            (p.Brand == brand || brand == null) &&
            (p.Category == category || category == null) &&
            (p.PrimaryColorCode == color || p.SecondaryColorCode == color || color == null) &&
            (p.Demographic == demographic || demographic == null) &&
            (p.Material == material || material == null) &&
            (p.Price == price || price.Equals(0)) &&
            (p.Type == type || type == null)).ToListAsync();
        }

    }

}
