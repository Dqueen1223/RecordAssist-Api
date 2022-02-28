using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task<Product> NoTrackingGetProductByIdAsync(int productId)
        {
           return  await _ctx.Products.Where(p => p.Id == productId).AsNoTracking().Take(1).FirstOrDefaultAsync();
        }

        public async Task<List<string>> GetAllUniqueProductCategoriesAsync()
        {
            return await _ctx.Products.Select(l => l.Category).Distinct().ToListAsync();
        }

        public async Task<List<string>> GetAllUniqueProductTypesAsync()
        {
            return await _ctx.Products.Select(l => l.Type).Distinct().ToListAsync();
        }

        public async Task<int> GetProductsCountAsync(Nullable<bool> active, List<string> brand, List<string> category,
                                                                         List<string> color, List<string> demographic, List<string> material,
                                                                         decimal minPrice, decimal maxPrice, List<string> type, int? range, int returnProducts)
        {
            return await _ctx.Products.Where(p =>
            (p.Active == active || active == null) &&
            (brand.Contains(p.Brand.ToLower()) || brand.Count() == 0) &&
            (category.Contains(p.Category.ToLower()) || category.Count() == 0) &&
            (color.Contains(p.PrimaryColorCode.ToLower()) || color.Contains(p.SecondaryColorCode.ToLower()) || color.Count() == 0) &&
            (demographic.Contains(p.Demographic.ToLower()) || demographic.Count() == 0) &&
            (material.Contains(p.Material.ToLower()) || material.Count() == 0) &&
            ((p.Price >= minPrice || minPrice.Equals(0)) && (p.Price <= maxPrice || maxPrice.Equals(0))) &&
            (type.Contains(p.Type.ToLower()) || type.Count() == 0)).Skip(count: (int)range).Take(returnProducts).CountAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(Nullable<bool> active, List<string> brand, List<string> category,
                                                                 List<string> color, List<string> demographic, List<string> material,
                                                                 decimal minPrice, decimal maxPrice, List<string> type, int? range, int returnProducts)
        {

            return await _ctx.Products.Where(p =>
            (p.Active == active || active == null) &&
            (brand.Contains(p.Brand.ToLower()) || brand.Count() == 0) &&
            (category.Contains(p.Category.ToLower()) || category.Count() == 0) &&
            (color.Contains(p.PrimaryColorCode.ToLower()) || color.Contains(p.SecondaryColorCode.ToLower()) || color.Count() == 0) &&
            (demographic.Contains(p.Demographic.ToLower()) || demographic.Count() == 0) &&
            (material.Contains(p.Material.ToLower()) || material.Count() == 0) &&
            ((p.Price >= minPrice || minPrice.Equals(0)) && (p.Price <= maxPrice || maxPrice.Equals(0))) &&
            (type.Contains(p.Type.ToLower()) || type.Count() == 0)).Skip(count: (int)range).Take(returnProducts).OrderBy((i)=>i.Id).ToListAsync();
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            await _ctx.Products.AddAsync(product);
            await _ctx.SaveChangesAsync();

            return product;
        }
        public async Task<Product> UpdateProductAsync(Product product)
        {
            _ctx.Products.Update(product);
            await _ctx.SaveChangesAsync();

            return product;
        }
    }

}
