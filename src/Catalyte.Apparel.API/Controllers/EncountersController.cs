using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RecordAssist.Health.DTOs.Encounters;
using RecordAssist.Health.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RecordAssist.Apparel.API.Controllers
{
    /// <summary>
    /// The EncounterssController exposes endpoints for encounter related actions.
    /// </summary>
    [ApiController]
    [Route("/encounters")]
    public class EncountersController : ControllerBase
    {
        private readonly ILogger<EncountersController> _logger;
        private readonly IPatientProvider _patientProvider;
        private readonly IMapper _mapper;

        public EncountersController(
            ILogger<EncountersController> logger,
            IPatientProvider patientProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _patientProvider = patientProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EncounterDTO>> GetAllEncountersAsync()
        {
            _logger.LogInformation("Request received for GetAllEncountersAsync");

            var encounters = await _patientProvider.GetAllEncountersAsync();
            var encounterDTO = _mapper.Map<IEnumerable<EncounterDTO>>(encounters);

            return Ok(encounterDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EncounterDTO>> GetEncounterByIdAsync(int id)
        {
            _logger.LogInformation("Request recieve fro GetEncounterByIdAsync");

            var encounter = await _patientProvider.GetEncounterByIdAsync(id);
            var encounterDTO = _mapper.Map<EncounterDTO>(encounter);

            return Ok(encounterDTO);
        }
    }
}



