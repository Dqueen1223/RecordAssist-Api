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
        public PatientsController(
            ILogger<PatientsController> logger,
            IPatientProvider patientProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _patientProvider = patientProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatientsAsync()
        {
            _logger.LogInformation("Request received for GetPatientsAsync");

            var patients = await _patientProvider.GetPatientsAsync(); 

            var patientDTOs = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            return Ok(patientDTOs);
        }

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
            var patientToUpdate = _mapper.Map<Patient>(Patient);
            {
                _logger.LogInformation("Request recived for update patient");
            }
            var updatedPatient = await _patientProvider.UpdatePatientAsync(id, patientToUpdate);
            var patientDTO = _mapper.Map<PatientDTO>(updatedPatient);

            return Ok(patientDTO);
        }
        [HttpPut("{patientId}/encounters/{encounterId}")]
        public async Task<ActionResult<EncounterDTO>> UpdateEncounterAsync(int patientId, int encounterId, [FromBody] EncounterDTO encounter)
        {
            _logger.LogInformation($"Request received for GetEncountersByEncounterIdAsync with encounter id: {encounterId} and patient id: {patientId}");
            var encounterToUpdate = _mapper.Map<Encounter>(encounter);
            var updatedEncounter = await _patientProvider.UpdateEncounterAsync(patientId, encounterId, encounterToUpdate);
            var encounterDTOs = _mapper.Map<EncounterDTO>(updatedEncounter);
            return Ok(encounterDTOs);
        }

        [HttpPost("{id}/encounters")]
        public async Task<ActionResult<EncounterDTO>> CreateEncounterAsync([FromBody] EncounterDTO Encounter)
        {
            _logger.LogInformation("Request recieve for CreateEncounter");
            var newEncounter = _mapper.MapEncounterDtotoEncounter(Encounter);
            var savedEncounter = await _patientProvider.CreateEncounterAsync(newEncounter);
            var encounterDTO = _mapper.Map<EncounterDTO>(savedEncounter);
            return Created($"/encounters", encounterDTO);
        }
        [HttpGet("{id}/encounters")]
        public async Task<ActionResult<EncounterDTO>> GetEncountersByPatientIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetEncountersByPatientIdAsync for id: {id}");
            var savedEncounter = await _patientProvider.GetEncountersByPatientIdAsync(id);
            var encounterDTOs = _mapper.Map <IEnumerable<EncounterDTO>>(savedEncounter);
            return Ok(encounterDTOs);
        }
        [HttpGet("{patientId}/encounters/{encounterId}")]
        public async Task<ActionResult<EncounterDTO>> GetEncounterByEncounterIdAsync(int patientId, int encounterId)
        {
            _logger.LogInformation($"Request received for GetEncountersByEncounterIdAsync with encounter id: {encounterId} and patient id: {patientId}");
            var savedEncounter = await _patientProvider.GetEncounterByEncounterIdAsync(patientId, encounterId);
            var encounterDTOs = _mapper.Map<EncounterDTO>(savedEncounter);
            return Ok(encounterDTOs);
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
    }
}
