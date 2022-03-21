//using Catalyte.Apparel.Data.Context;
//using Catalyte.Apparel.Data.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Catalyte.Apparel.Data.Repositories
//{
//    /// <summary>
//    /// This class handles methods for making requests to the LineItems repository.
//    /// </summary>
//    public class LineItemsRepository : ILineItemsRepository
//    {
//        private readonly IApparelCtx _ctx;

//        public LineItemsRepository(IApparelCtx ctx)
//        {
//            _ctx = ctx;
//        }

//        public async Task<bool> GetLineItemsByProductIdAsync(int productId)
//        {
//            var purchasedProduct = await _ctx.LineItems
//                .Where(l => l.ProductId == productId)
//                .AnyAsync();

//            return purchasedProduct;
//        }
//    }
//}