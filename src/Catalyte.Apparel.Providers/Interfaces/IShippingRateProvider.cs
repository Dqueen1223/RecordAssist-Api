using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product related service methods.
    /// </summary>
    public interface IShippingRateProvider
    {
        Task<decimal> GetProductRateByNameAsync(string state);
    }
}
