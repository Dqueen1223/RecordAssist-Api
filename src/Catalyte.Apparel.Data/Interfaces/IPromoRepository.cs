﻿using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for promo repository methods.
    /// </summary>
    public interface IPromoRepository
    {
        Task<Promo> CreatePromoAsync(Promo model);

        //Task<Promo> GetAllPromosByName(string name);
    }
}
