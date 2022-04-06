using AutoMapper;
using RecordAssist.Health.Data.Interfaces;
using RecordAssist.Health.Data.Model;
using RecordAssist.Health.Providers.Interfaces;
using RecordAssist.Health.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RecordAssist.Health.Providers.Providers
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
    }
}
