﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.API.DTOMappings;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Patients;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PatientDTO>> GetPatientByIdAsync(int id)
        //{
        //    _logger.LogInformation($"Request received for GetPatientByIdAsync for id: {id}");

        //    var patient = await _patientProvider.GetPatientByIdAsync(id);
        //    var patientDTO = _mapper.Map<PatientDTO>(patient);

        //    return Ok(patientDTO);
        //}

        [HttpPut]
        public async Task<ActionResult<PatientDTO>> UpdatePatientAsync(
                        [FromBody] PatientDTO Patient)
        {
            _logger.LogInformation("Request received for update user");

            var patientToUpdate = _mapper.Map<Patient>(Patient);
            {
                _logger.LogInformation("Request recived for update patient");
            }
            var updatedPatient = await _patientProvider.UpdatePatientAsync(patientToUpdate);
            var patientDTO = _mapper.Map<PatientDTO>(updatedPatient);

            return Ok(patientDTO);
        }
        [HttpGet("/patients/categories")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllUniquePatientCategoriesAsync()
        {
            _logger.LogInformation($"Request received for GetAllUniquePatientCategoriesAsync");
            var patientCategories = await _patientProvider.GetAllUniquePatientCategoriesAsync();
            return Ok(patientCategories);

        }

        [HttpGet("/patients/types")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllUniquePatientTypesAsync()
        {
            _logger.LogInformation($"Request received for GetAllUniquePatientTypesAsync");
            var patientTypes = await _patientProvider.GetAllUniquePatientTypesAsync();
            return Ok(patientTypes);

        }

        [HttpPost]
        public async Task<ActionResult<List<PatientDTO>>> CreatePatientAsync([FromBody] PatientDTO model)
        {
            _logger.LogInformation("Request received for CreatePatient");
            var newPatient = _mapper.MapCreatePatientDtoToPatient(model);
            var savedPatient = await _patientProvider.CreatePatientAsync(newPatient);
            var patientDTO = _mapper.MapPatientToPatientDto(savedPatient);
            return Created($"/maintenance", patientDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientDTO>> DeletePatientByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for DeletePatientByIdAsync for id: {id}");

            await _patientProvider.DeletePatientByIdAsync(id);


            return Ok("Patient successfully deleted.");
        }

        [HttpGet("/patients/purchased/{patientId}")]
        public async Task<ActionResult<bool>> CheckForPurchasesByPatientIdAsync(int patientId)
        {
            _logger.LogInformation("Request received for CheckForPurchasesByPatientIdAsync.");
            var patient = await _patientProvider.GetPatientByIdAsync(patientId);
            var purchasedPatient = await _patientProvider.CheckForPurchasesByPatientIdAsync(patientId, patient);

            return Ok(purchasedPatient);

        }
    }
}