using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Catalyte.Apparel.Utilities.Validation;
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

        public PromoProvider(IPromoRepository promoRepository, ILogger<PromoProvider> logger)
        {
            _logger = logger;
            _promoRepository = promoRepository;
        }
        public async Task<Promo> CreatePromoAsync(Promo newPromo)
        {
            Promo savedPromo;
            List<string> errors = Validation.PromoValidation(newPromo);
            if (errors.Count > 0)
            {
                throw new BadRequestException(string.Join(' ', errors));
            }
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
        public async Task<Promo> GetPromoByCodeAsync(string Code)
        {
            Promo SavedPromo;

            try
            {
                SavedPromo = await _promoRepository.GetPromoByCodeAsync(Code);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (SavedPromo == null)
            {
                return new Promo();
            }
            return SavedPromo;
        }
    }
}
