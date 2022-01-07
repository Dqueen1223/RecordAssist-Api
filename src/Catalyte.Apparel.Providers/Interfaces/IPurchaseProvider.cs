using System.Collections.Generic;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Purchases;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyte.Apparel.DTOs.Purchases;

namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for purchase related service methods.
    /// </summary>
    public interface IPurchaseProvider
    {
        Task<IEnumerable<Purchase>> GetAllPurchasesByEmailAsync(string email);

        Task<Purchase> CreatePurchasesAsync(Purchase model);

        Task<string> CheckForInactiveProductsAsync(Purchase purchase);
    }
}
