using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Filters;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the product repository.
    /// </summary>
    public class PromoRepository : IPromoRepository
    {
        private readonly IApparelCtx _ctx;

        public PromoRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Promo> CreatePromoAsync(Promo model)
        {
            await _ctx.Promos.AddAsync(model);
            await _ctx.SaveChangesAsync();
            return model;
        }
        public async Task<Promo> GetPromoByCodeAsync(string Code)
        {
            return await _ctx.Promos.AsQueryable().WherePromoCodeEquals(Code).FirstOrDefaultAsync();
        }
    }
}
