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

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _ctx.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandAsync(string productBrand)
        {
            return await _ctx.Products.Where(p => p.Brand == productBrand).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string productCategory)
        {
            return await _ctx.Products.Where(p => p.Category == productCategory).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByColorAsync(string productColor)
        {
            return await _ctx.Products.Where(p => p.PrimaryColorCode == productColor || p.SecondaryColorCode == productColor).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByDemographicAsync(string productDemographic)
        {
            return await _ctx.Products.Where(p => p.Demographic == productDemographic).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByMaterialAsync(string productMaterial)
        {
            return await _ctx.Products.Where(p => p.Material == productMaterial).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal productPrice)
        {
            return await _ctx.Products.Where(p => p.Price == productPrice).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByTypeAsync(string productType)
        {
            return await _ctx.Products.Where(p => p.Type == productType).ToListAsync();
        }
    }

}
