using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for purchase repository methods.
    /// </summary>
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GetAllPurchasesByEmailAsync(string email);

        Task<Purchase> CreatePurchaseAsync(Purchase purchase);
    }
}
