using Catalyte.Apparel.Data.Model;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for LineItems repository methods.
    /// </summary>
    public interface ILineItemsRepository
    {
        Task<LineItem> GetLineItemsByProductIdAsync(int productId);
    }
}