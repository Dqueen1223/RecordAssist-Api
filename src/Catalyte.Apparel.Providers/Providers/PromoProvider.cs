using AutoMapper;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IProductProvider interface, providing service methods for products.
    /// </summary>
    public class PromoProvider : IPromoProvider
    {
        private readonly ILogger<PromoProvider> _logger;
        private readonly IPromoRepository _promoRepository;
        private readonly IPromoProvider _promoProvider;
        private readonly IMapper _mapper;

        public PromoProvider(IPromoRepository promoRepository, ILogger<PromoProvider> logger, IPromoProvider promoProvider, IMapper mapper)
        {
            _logger = logger;
            _promoRepository = promoRepository;
            _promoProvider = promoProvider;
            _mapper = mapper;
        }
        public async Task<Promo> CreatePromoAsync(Promo newPromo)
        {
            Promo savedPromo;

                try
                {
                    savedPromo = await _promoRepository.CreatePromoAsync(newPromo);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new ServiceUnavailableException("There was a problem connecting to the database.");
                }
            return savedPromo;
        }

    }
}
