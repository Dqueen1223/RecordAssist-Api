using System.Collections.Generic;
using System.Linq;
using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.Data.Filters
{
    /// <summary>
    /// Filter collection for product context queries.
    /// </summary>
    public static class ProductFilters
    {
        public static IQueryable<Product> WhereProductIdEquals(this IEnumerable<Product> products, int productId)
        {
            return products.Where(i => i.Id == productId).AsQueryable();
        }

        public static IQueryable<Product> WhereProductCategoryEquals(this IEnumerable<Product> products, string productCategory)
        {
            return products.Where(i => i.Category == productCategory).AsQueryable();
        }

        //public static IQueryable<Product> WhereProductDemographicEquals(this IEnumerable<Product> products, string productDemographic)
        // {
        //     return products.Where(i => i.Demographic == productDemographic).AsQueryable();
        //}

        public static IQueryable<Product> WhereProductColorEquals(this IEnumerable<Product> products, string productColor)
        {
            return products.Where(i => i.PrimaryColorCode == productColor || i.SecondaryColorCode == productColor).AsQueryable();
        }

    }
}
