using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.API.DTOMappings;
using Catalyte.Apparel.DTOs.Encounters;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
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
    }
}



