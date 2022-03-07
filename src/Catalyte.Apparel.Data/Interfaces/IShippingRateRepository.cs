using System.Threading.Tasks;


namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for shipping rate related service methods.
    /// </summary>
    public interface IShippingRateRepository
    {
        Task<decimal> GetProductRateByNameAsync(string name);
    }
}
