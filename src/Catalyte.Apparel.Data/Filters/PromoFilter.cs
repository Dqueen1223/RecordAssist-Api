using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Filters
{
    /// <summary>
    /// Filter collection for Promo context queries.
    /// </summary>
    public static class PromoFilter
    {
        public static IQueryable<Promo> WherePromoCodeEquals(this IQueryable<Promo> promos, string Code)
        {
            return promos.Where(u => u.Code == Code).AsQueryable();
        }
    }
}
