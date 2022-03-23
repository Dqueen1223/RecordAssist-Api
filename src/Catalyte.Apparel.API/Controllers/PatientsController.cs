using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.API.DTOMappings;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Patients;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Catalyte.Apparel.DTOs.Encounters;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The PatientsController exposes endpoints for patient related actions.
    /// </summary>
    [ApiController]
    [Route("/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;
        private readonly IPatientProvider _patientProvider;
        private readonly IMapper _mapper;
        private readonly IEncounterProvider _encountersProvider;
        public PatientsController(
            ILogger<PatientsController> logger,
            IPatientProvider patientProvider,
            IMapper mapper,
             IEncounterProvider encountersProvider)
        {
            _logger = logger;
            _mapper = mapper;
            _patientProvider = patientProvider;
            _encountersProvider = encountersProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatientsAsync()
        //Nullable<bool> active, [FromQuery] List<string> brand,
        //[FromQuery] List<string> category,
        //[FromQuery] List<string> color,
        //[FromQuery] List<string> demographic,
        //[FromQuery] List<string> material,
        //decimal minPrice, decimal maxPrice,
        //[FromQuery] List<string> type, int? range)
        {
            _logger.LogInformation("Request received for GetPatientsAsync");

            var patients = await _patientProvider.GetPatientsAsync(); /*active, brand, category, color,*/
            //demographic, material,
            //minPrice, maxPrice, type, range);

            var patientDTOs = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            return Ok(patientDTOs);
        }
        //[HttpGet("/patients/count")]
        //public async Task<ActionResult<int>> GetPatientsCountAsync(Nullable<bool> active, [FromQuery] List<string> brand,
        //                                                                          [FromQuery] List<string> category,
        //                                                                          [FromQuery] List<string> color,
        //                                                                          [FromQuery] List<string> demographic,
        //                                                                          [FromQuery] List<string> material,
        //                                                                          decimal minPrice, decimal maxPrice,
        //                                                                          [FromQuery] List<string> type, int? range)
        //{
        //    _logger.LogInformation("Request received for GetPatientsAsync");

        //    var patientsCount = await _patientProvider.GetPatientsCountAsync(active, brand, category, color,
        //                                                           demographic, material,
        //                                                           minPrice, maxPrice, type, range);

        //    return Ok(patientsCount);
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> GetPatientByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetPatientByIdAsync for id: {id}");

            var patient = await _patientProvider.GetPatientByIdAsync(id);
            var patientDTO = _mapper.Map<PatientDTO>(patient);

            return Ok(patientDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PatientDTO>> UpdatePatientAsync(
                        int id, [FromBody] PatientDTO Patient)
        {
            _logger.LogInformation("Request received for update user");

            var patientToUpdate = _mapper.Map<Patient>(Patient);
            {
                _logger.LogInformation("Request recived for update patient");
            }
            var updatedPatient = await _patientProvider.UpdatePatientAsync(id, patientToUpdate);
            var patientDTO = _mapper.Map<PatientDTO>(updatedPatient);

            return Ok(patientDTO);
        }
        //[HttpGet("/patients/categories")]
        //public async Task<ActionResult<IEnumerable<string>>> GetAllUniquePatientCategoriesAsync()
        //{
        //    _logger.LogInformation($"Request received for GetAllUniquePatientCategoriesAsync");
        //    var patientCategories = await _patientProvider.GetAllUniquePatientCategoriesAsync();
        //    return Ok(patientCategories);

        //}

        //[HttpGet("/patients/types")]
        //public async Task<ActionResult<IEnumerable<string>>> GetAllUniquePatientTypesAsync()
        //{
        //    _logger.LogInformation($"Request received for GetAllUniquePatientTypesAsync");
        //    var patientTypes = await _patientProvider.GetAllUniquePatientTypesAsync();
        //    return Ok(patientTypes);

        //}
        [HttpPost("/encounters")]
        public async Task<ActionResult<EncounterDTO>> CreateEncounterAsync([FromBody] EncounterDTO Encounter)
        {
            var newEncounter = _mapper.MapEncounterDtotoEncounter(Encounter);
            var savedEncounter = await _patientProvider.CreateEncounterAsync(newEncounter);
            var encounterDTO = _mapper.Map<EncounterDTO>(savedEncounter);
            return Created($"/patients", encounterDTO);
        }
        [HttpPost]
        public async Task<ActionResult<PatientDTO>> CreatePatientAsync([FromBody] PatientDTO patient)
        {
            _logger.LogInformation("Request received for CreatePatient");
            var newPatient = _mapper.MapPatientDtoToPatient(patient);
            var savedPatient = await _patientProvider.CreatePatientAsync(newPatient);
            var patientDTO = _mapper.MapPatientToPatientDTO(savedPatient);
            return Created($"/patients", patientDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientDTO>> DeletePatientByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for DeletePatientByIdAsync for id: {id}");

            await _patientProvider.DeletePatientByIdAsync(id);


            return NoContent();
        }

        //[HttpGet("/patients/purchased/{patientId}")]
        //public async Task<ActionResult<bool>> CheckForPurchasesByPatientIdAsync(int patientId)
        //{
        //    _logger.LogInformation("Request received for CheckForPurchasesByPatientIdAsync.");
        //    var patient = await _patientProvider.GetPatientByIdAsync(patientId);
        //    var purchasedPatient = await _patientProvider.CheckForPurchasesByPatientIdAsync(patientId, patient);

        //    return Ok(purchasedPatient);

        //}
    }
}
