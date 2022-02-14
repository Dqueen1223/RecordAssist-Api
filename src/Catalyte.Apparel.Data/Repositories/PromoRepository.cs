using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
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
    }
}
