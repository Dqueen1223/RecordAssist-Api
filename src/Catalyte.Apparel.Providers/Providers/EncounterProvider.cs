using AutoMapper;
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
    /// This class provides the implementation of the IEncounterProvider interface, providing service methods for encounters.
    /// </summary>
    public class EncounterProvider : IEncounterProvider
    {
        private readonly ILogger<EncounterProvider> _logger;
        private readonly IEncounterRepository _encounterRepository;
        private readonly IPatientProvider _patientProvider;
        private readonly IMapper _mapper;
        //private readonly IEncounterProvider -en

        public EncounterProvider(IEncounterRepository encounterRepository, ILogger<EncounterProvider> logger, IMapper mapper, IPatientProvider patientProvider)
        {
            _logger = logger;
            _encounterRepository = encounterRepository;
            _mapper = mapper;
            _patientProvider = patientProvider;
        }

        /// <summary>
        /// Persists a encounter to the database.
        /// </summary>
        /// <param name="model">EncounterDTO used to build the encounter.</param>
        /// <returns>The persisted encounter with IDs.</returns>
        public async Task<Encounter> CreateEncounterAsync(Encounter newEncounter)
        {
            Encounter savedEncounter;

            try
            {
                savedEncounter = await _encounterRepository.CreateEncounterAsync(newEncounter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return savedEncounter;
        }
        ///// <summary>
        /// Checks encounter to see if it contains inactive patients
        /// </summary>
        /// <param name="newEncounter">Encounter is the encounter to check.</param>
        /// <returns>string of patient names from encounter that are inactive</returns>
        //    public async Task<string> CheckForEncouterlessPatientsAsync(Patient newPatient)
        //    {
        //        string inactives = string.Empty;

        //        var patient = await _patientProvider.GetEncounterByIdAsync(newPatient.Id);
        //        if (!patient.Active)
        //        {
        //            inactives += (patient.Name + " , ");
        //        }
        //    }
        //    if (inactives != string.Empty)
        //    {
        //        return inactives.Remove(inactives.Length - 3);
        //    }
        //    else
        //{
        //    return inactives;
        //}
    }
}
