//using System.Collections.Generic;
//using System.Threading.Tasks;
//using AutoMapper;
//using Catalyte.Apparel.API.DTOMappings;
//using Catalyte.Apparel.DTOs.Encounters;
//using Catalyte.Apparel.Providers.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//namespace Catalyte.Apparel.API.Controllers
//{
//    /// <summary>
//    /// The EncounterssController exposes endpoints for encounter related actions.
//    /// </summary>
//    [ApiController]
//    [Route("/encounters")]
//    public class EncountersController : ControllerBase
//    {
//        private readonly ILogger<EncountersController> _logger;
//        private readonly IEncounterProvider _EncounterProvider;
//        private readonly IMapper _mapper;

//        public EncountersController(
//            ILogger<EncountersController> logger,
//            IEncounterProvider encounterProvider,
//            IMapper mapper
//        )
//        {
//            _logger = logger;
//            _EncounterProvider = encounterProvider;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<EncounterDTO>>> GetAllEncountersByEmailAsync(string email)
//        {
//            _logger.LogInformation("Request received for GetAllEncountersAsync");

//            var encounters = await _EncounterProvider.GetAllEncountersByEmailAsync(email);
//            var encounterDTOs = _mapper.MapEncountersToEncounterDtos(encounters);

//            return Ok(encounterDTOs);
//        }

//        [HttpPost]
//        public async Task<ActionResult<List<EncounterDTO>>> CreateEncounterAsync([FromBody] EncounterDTO model)
//        {
//            _logger.LogInformation("Request received for CreateEncounter");

//            var newEncounter = _mapper.MapCreateEncounterDtoToEncounter(model);
//            var savedEncounter = await _EncounterProvider.CreateEncountersAsync(newEncounter);
//            var encounterDTO = _mapper.MapEncounterToEncounterDto(savedEncounter);
//            return Created($"/encounters/", encounterDTO);
//        }
//    }
//}



