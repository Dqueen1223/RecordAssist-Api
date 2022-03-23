//using AutoMapper;
//using Catalyte.Apparel.Data.Interfaces;
//using Catalyte.Apparel.Data.Model;
//using Catalyte.Apparel.Providers.Interfaces;
//using Catalyte.Apparel.Utilities.HttpResponseExceptions;
//using Catalyte.Apparel.Utilities.Validation;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Catalyte.Apparel.Providers.Providers
//{
//    /// <summary>
//    /// This class provides the implementation of the IEncounterProvider interface, providing service methods for encounters.
//    /// </summary>
//    public class EncounterProvider : IEncounterProvider
//    {
//        private readonly ILogger<EncounterProvider> _logger;
//        private readonly IEncounterRepository _encounterRepository;
//        //private readonly IProductProvider _productProvider;
//        private readonly IMapper _mapper;

//        public EncounterProvider(IEncounterRepository encounterRepository, ILogger<EncounterProvider> logger, IMapper mapper)
//        {
//            _logger = logger;
//            _encounterRepository = encounterRepository;
//            _mapper = mapper;
//        }

//        /// <summary>
//        /// Retrieves all encounters from the database.
//        /// </summary>
//        /// <param name="email">An existing email </param>
//        /// <returns>All encounters.</returns>
//        public async Task<IEnumerable<Encounter>> GetAllEncountersByEmailAsync(string email)
//        {
//            List<Encounter> encounters;
//            if (string.IsNullOrEmpty(email))
//            {
//                throw new NotFoundException("No email specified for request.");
//            }
//            encounters = await _encounterRepository.GetAllEncountersByEmailAsync(email);
//            return encounters;
//        }

        /// <summary>
        /// Persists a encounter to the database.
        /// </summary>
        /// <param name="model">EncounterDTO used to build the encounter.</param>
        /// <returns>The persisted encounter with IDs.</returns>
        //public async Task<Encounter> CreateEncountersAsync(Encounter newEncounter)
        //{
        //    Encounter savedEncounter;

        //    //var inactiveProducts = await CheckForInactiveProductsAsync(newEncounter);
        //    //if (inactiveProducts != string.Empty)
        //    //{
        //    //    throw new UnprocessableEntityException("Cannot encounter inactive products:  "
        //    //        + inactiveProducts);
        //    //}

        //    //List<string> errors = Validation.CreditCardValidation(newEncounter);
        //    //if (errors.Count > 0)
        //    //    throw new BadRequestException(string.Join(' ', errors));

        //    try
        //    {
        //        savedEncounter = await _encounterRepository.CreateEncounterAsync(newEncounter);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        throw new ServiceUnavailableException("There was a problem connecting to the database.");
        //    }
        //    return savedEncounter;
        //}

        ///// <summary>
        /// Checks encounter to see if it contains inactive products
        /// </summary>
        /// <param name="newEncounter">Encounter is the encounter to check.</param>
        /// <returns>string of product names from encounter that are inactive</returns>
        //public async Task<string> CheckForInactiveProductsAsync(Encounter newEncounter)
        //{
        //    string inactives = string.Empty;

        //    var product = await _productProvider.GetProductByIdAsync();
        //    if (!product.Active)
        //    {
        //        inactives += (product.Name + " , ");
        //    }
        //}
        //    if (inactives != string.Empty)
        //    {
        //        return inactives.Remove(inactives.Length - 3);
        //    }
        //    else
        //    {
        //        return inactives;
        //    }
        //}
//    }
//}

