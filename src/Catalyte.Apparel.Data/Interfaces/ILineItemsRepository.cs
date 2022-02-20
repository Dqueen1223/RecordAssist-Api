using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for LineItems repository methods.
    /// </summary>
    public interface ILineItemsRepository
    {
        Task<List<LineItem>> GetLineItemsByProductIdAsync(int productId);
    }
}