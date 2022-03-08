using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the Shipping Rate repository.
    /// </summary>
    public class ShippingRateRepository : IShippingRateRepository
    {
        private readonly IApparelCtx _ctx;

        public ShippingRateRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<decimal> GetProductRateByNameAsync(string name)
        {
            return await _ctx.ShippingRates.Where(u => u.State == name).Select(u => u.ShippingCost).SingleOrDefaultAsync();
        }


    }

}
