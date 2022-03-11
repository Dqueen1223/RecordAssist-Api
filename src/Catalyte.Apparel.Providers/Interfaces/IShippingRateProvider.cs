using System.Threading.Tasks;


namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for shipping rate related service methods.
    /// </summary>
    public interface IShippingRateProvider
    {
        Task<decimal> GetProductRateByNameAsync(string state);
    }
}
