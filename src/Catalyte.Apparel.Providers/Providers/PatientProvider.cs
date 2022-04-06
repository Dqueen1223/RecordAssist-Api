using RecordAssist.Health.Data.Interfaces;
using RecordAssist.Health.Data.Model;
using RecordAssist.Health.Providers.Interfaces;
using RecordAssist.Health.Utilities.HttpResponseExceptions;
using RecordAssist.Health.Utilities.Validation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordAssist.Health.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IpatientProvider interface, providing service methods for Patients.
    /// </summary>
    public class PatientProvider : IPatientProvider
    {
        private readonly ILogger<PatientProvider> _logger;
        private readonly IPatientRepository _patientRepository;

        public PatientProvider(IPatientRepository patientRepository, ILogger<PatientProvider> logger)
        {
            _logger = logger;
            _patientRepository = patientRepository;
        }


        /// Asynchronously retrieves the patient with the provided id from the database.
        /// </summary>
        /// <param name="patientId">The id of the patient to retrieve.</param>
        /// <returns>The patient.</returns>
        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            Patient patient;

            try
            {
                patient = await _patientRepository.GetPatientByIdAsync(patientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (patient == null || patient == default)
            {
                _logger.LogInformation($"Patient with id: {patientId} could not be found.");
                throw new NotFoundException($"Patient with id: {patientId} could not be found.");
            }

            return patient;
        }

        /// Asynchronously retrieves the Encounter with the provided  patient id from the database.
        /// </summary>
        /// <param name="patientId">The id of the patient to retrieve.</param>
        /// <returns>The Encounter.</returns>
        public async Task<IEnumerable<Encounter>> GetEncountersByPatientIdAsync(int patientId)
        {
            IEnumerable<Encounter> encounter;

            try
            {
                encounter = await _patientRepository.GetEncountersByPatientIdAsync(patientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (encounter == null || encounter == default)
            {
                _logger.LogInformation($"Encounter with id: {patientId} could not be found.");
                throw new NotFoundException($"Encounter with id: {patientId} could not be found.");
            }

            return encounter;
        }
        /// Asynchronously retrieves the encounter with the provided id from the database.
        /// </summary>
        /// <param name="patientId">The id of the patient to retrieve.</param> 
        /// <param name="encounterId">The id of the encounter to retrieve.</param>
        /// <returns>The Encounter.</returns>
        public async Task<Encounter> GetEncounterByEncounterIdAsync(int patientId, int encounterId)
        {
            Encounter encounter;
            try
            {
                encounter = await _patientRepository.GetEncounterByEncounterIdAsync(patientId, encounterId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (encounter == null || encounter == default)
            {
                _logger.LogInformation($"Encounter with id: {encounterId} and patient id: {patientId} could not be found.");
                throw new NotFoundException($"Encounter with id: {encounterId} and patient id: {patientId} could not be found.");
            }

            return encounter;
        }
        public async Task<Encounter> GetEncounterByIdAsync(int id)
        {
            Encounter encounter;
            try
            {
                encounter = await _patientRepository.GetEncounterByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (encounter == null || encounter == default)
            {
                _logger.LogInformation($"Encounter with id: {id} could not be found.");
                throw new NotFoundException($"Encounter with id: {id} could not be found.");
            }

            return encounter;
        }
        /// <summary>
        /// Asynchronously retrieves nontracked Patient with the provided id from the database.
        /// </summary>
        /// <param name="patientId">The id of the patient to retrieve.</param>
        /// <returns>The patient.</returns>
        ///  /// <summary>
        public async Task<Patient> NoTrackingGetPatientByIdAsync(int patientId)
        {
            Patient patient;

            try
            {
                patient = await _patientRepository.NoTrackingGetPatientByIdAsync(patientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (patient == null || patient == default)
            {
                _logger.LogInformation($"Patient with id: {patientId} could not be found.");
                throw new NotFoundException($"Patient with id: {patientId} could not be found.");
            }

            return patient;
        }

        public async Task<Patient> NoTrackingCheckConflictingEmail(string patientEmail)
        {
            Patient CheckExistingEmail;
            try
            {
                CheckExistingEmail = await _patientRepository.NoTrackingCheckConflictingEmail(patientEmail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (CheckExistingEmail != null)
            {
                throw new ConflictException("This email is already taken");
            }
            return null;
        }


        /// <summary>
        /// Asynchronously retrieves all patients from the database.
        /// </summary>
        /// <returns>All patients in the database.</returns>
        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            IEnumerable<Patient> patients;
            try
            {
                patients = await _patientRepository.GetPatientsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return patients;
        }

        /// <summary>
        /// Asynchronously retrieves all encounters from the database.
        /// </summary>
        /// <returns>All encounters in the database.</returns>
        public async Task<IEnumerable<Encounter>> GetAllEncountersAsync()
        {
            IEnumerable<Encounter> encounters;
            try
            {
                encounters = await _patientRepository.GetAllEncountersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return encounters;
        }

        /// <summary>
        /// Asynchronously updates encounter with new encounter information
        /// </summary>
        /// <param name="updatedPatient"></param>
        /// <returns> The updated encounter</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="BadRequestException"></exception>
        public async Task<Encounter> UpdateEncounterAsync(int patientId, int encounterId, Encounter updatedEncounter)
        {
            Encounter newEncounter;

            Encounter existingEncounter;
            List<string> errors = Validation.EncounterValidation(updatedEncounter);
            if (errors.Count > 0)
            {
                throw new BadRequestException(string.Join(' ', errors));
            }
            try
            {
                existingEncounter = await _patientRepository.NoTrackingGetEncounterByEncounterIdAsync(patientId, encounterId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            try
            {
                newEncounter = await _patientRepository.UpdateEncounterAsync(updatedEncounter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (existingEncounter == null)
            {
                _logger.LogInformation($"Patient with id: {patientId} and Encounter with id: {encounterId} does not exist.");
                throw new NotFoundException($"Patient with id: {patientId} and Encounter with id: {encounterId} does not exist.");
            }
            if (updatedEncounter.Id == 0)
            {
                _logger.LogInformation("Encounter body must have an Id associated");
                throw new BadRequestException("Encounter body must have an Id associated");
            }
            if (updatedEncounter.Id != existingEncounter.Id)
            {
                _logger.LogInformation("Body Id and path Id must be identical");
                throw new BadRequestException("Body Id and path Id must be identical");
            }


            return updatedEncounter;

        }
        /// <summary>
        /// Asynchronously updates patient with new patient information
        /// </summary>
        /// <param name="updatedPatient"></param>
        /// <returns> The updated patient</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="BadRequestException"></exception>
        public async Task<Patient> UpdatePatientAsync(int id, Patient updatedPatient)
        {
            Patient newPatient;

            Patient checkValidEmail;

            Patient existingPatient;
            List<string> errors = Validation.PatientValidation(updatedPatient);
            if (errors.Count > 0)
            {
                throw new BadRequestException(string.Join(' ', errors));
            }
            try
            {
                existingPatient = await _patientRepository.NoTrackingGetPatientByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (existingPatient == null)
            {
                _logger.LogInformation($"Patient with id: {id} does not exist.");
                throw new NotFoundException($"Patient with id:{id} not found.");
            }
            if (updatedPatient.Id == 0)
            {
                _logger.LogInformation("Patient body must have an Id associated");
                throw new BadRequestException("Patient body must have an Id associated");
            }
            if (updatedPatient.Id != existingPatient.Id)
            {
                _logger.LogInformation("Body Id and path Id must be identical");
                throw new BadRequestException("Body Id and path Id must be identical");
            }
            try
            {
                checkValidEmail = await _patientRepository.NoTrackingCheckConflictingEmail(updatedPatient.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (checkValidEmail != null && checkValidEmail.Id != updatedPatient.Id && checkValidEmail.Email == updatedPatient.Email)
            {
                _logger.LogInformation("This email has already been used");
                throw new ConflictException("This email has already been used");
            }
            try
            {
                newPatient = await _patientRepository.UpdatePatientAsync(updatedPatient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return newPatient;
        }
        /// <summary>
        /// Persists a patient to the database.
        /// </summary>
        /// <param name="newPatient"></param>
        /// <returns>The persisted patient with IDs</returns>
        /// <exception cref="BadRequestException"></exception>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="ConflictException"></exception>   
        public async Task<Patient> CreatePatientAsync(Patient newPatient)
        {
            Patient savedPatient;
            Patient checkValidId;
            Patient checkValidEmail;

            List<string>? errors = Validation.PatientValidation(newPatient);
            if (errors.Count > 0)
            {
                throw new BadRequestException(string.Join(' ', errors));
            }
            try
            {
                checkValidEmail = await _patientRepository.NoTrackingCheckConflictingEmail(newPatient.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (checkValidEmail != null && checkValidEmail.Email == newPatient.Email)
            {
                _logger.LogError("This email has already been used");
                throw new ConflictException("This email has already been used");
            }
            try
            {
                checkValidId = await _patientRepository.NoTrackingGetPatientByIdAsync(newPatient.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (checkValidId != null && checkValidId.Id == newPatient.Id)
            {
                _logger.LogError("This Id has already been used");
                throw new ConflictException("This Id has already been used");
            }
            try
            {
                savedPatient = await _patientRepository.CreatePatientAsync(newPatient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return savedPatient;
        }

        /// <summary>
        /// Deletes a patient by the patient id.
        /// </summary>
        /// <param name="id">The id of the patient to be deleted</param>
        /// <returns>the deleted patient object</returns>
        public async Task<Patient> DeletePatientByIdAsync(int id)
        {
            Patient existingPatient;
            Patient deletedPatient;
            IEnumerable<Encounter> encounter;
            try
            {
                existingPatient = await _patientRepository.GetPatientByIdAsync(id);
                if (existingPatient == null)
                {
                    _logger.LogInformation($"Patient with id: {id} does not exist.");
                    throw new NotFoundException($"Patient with id:{id} not found.");
                }
                encounter = await _patientRepository.GetEncountersByPatientIdAsync(id);
                if (encounter.Count() != 0)
                {
                    _logger.LogInformation($"Patient with id: {id} has encounters and cannot be deleted");
                    throw new ConflictException($"Patient with id: {id} has encounters and cannot be deleted");
                }
                else
                {
                    deletedPatient = await _patientRepository.DeletePatientByIdAsync(existingPatient);
                    return deletedPatient;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }
        /// <summary>
        /// Creates a new Encounter based off of valid encounter information
        /// </summary>
        /// <param name="newEncounter"></param>
        /// <returns>A created Encounter</returns>
        /// <exception cref="BadRequestException"></exception>
        /// <exception cref="ServiceUnavailableException"></exception>
        public async Task<Encounter> CreateEncounterAsync(Encounter newEncounter)
        {
            Encounter savedEncounter;

            List<string> errors = Validation.EncounterValidation(newEncounter);
            if (errors.Count > 0)
            {
                throw new BadRequestException(string.Join(' ', errors));
            }
            try
            {
                savedEncounter = await _patientRepository.CreateEncounterAsync(newEncounter);
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
