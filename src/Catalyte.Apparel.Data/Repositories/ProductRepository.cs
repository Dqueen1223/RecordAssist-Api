using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

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


        public async Task<IEnumerable<Product>> GetProductsAsync(Nullable<bool> active, List<string> brand, List<string> category,
                                                                 List<string> color, List<string> demographic, List<string> material,
                                                                 decimal price, List<string> type)
        {
            return await _ctx.Products.Where(p =>
            (p.Active == active || active == null) &&
            (brand.Contains(p.Brand) || brand.Count() == 0) &&
            (category.Contains(p.Category) || category.Count() == 0) &&
            (color.Contains(p.PrimaryColorCode) || color.Contains(p.SecondaryColorCode) || color.Count() == 0) &&
            (demographic.Contains(p.Demographic) || demographic.Count() == 0) &&
            (material.Contains(p.Material) || material.Count() == 0) &&
            (p.Price == price || price.Equals(0)) &&
            (type.Contains(p.Type) || type.Count() == 0)).ToListAsync();
        }

    }

}
