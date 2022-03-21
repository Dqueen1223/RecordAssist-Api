using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using Catalyte.Apparel.Utilities.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;



namespace Catalyte.Apparel.Providers.Providers
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
        /// <summary>
        /// Asynchronously retrieves all unique patient categories in the database 
        /// </summary>
        /// <returns>list of strings of categories</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        //public async Task<List<string>> GetAllUniquePatientCategoriesAsync()
        //{
        //    List<string> categories;

        //    try
        //    {
        //        categories = await _patientRepository.GetAllUniquePatientCategoriesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        throw new ServiceUnavailableException("There was a problem connecting to the database.");
        //    }
        //    return categories;
        //}
        ///// <summary>
        ///// Asynchronously retrieves all unique patient types in the database 
        ///// </summary>
        ///// <returns>list of strings of categories</returns>
        ///// <exception cref="ServiceUnavailableException"></exception>
        //public async Task<List<string>> GetAllUniquePatientTypesAsync()
        //{
        //    List<string> categories;

        //    try
        //    {
        //        categories = await _patientRepository.GetAllUniquePatientTypesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        throw new ServiceUnavailableException("There was a problem connecting to the database.");
        //    }
        //    return categories;
        //}

        //public async Task<int> GetPatientsCountAsync(Nullable<bool> active, List<string> brand, List<string> category,
        //                                                         List<string> color, List<string> demographic, List<string> material,
        //                                                         decimal minPrice, decimal maxPrice, List<string> type, int? range)
        //{
        //    {
        //        int patientsCount;

        //        int returnPatients = 20;
        //        if (range == null)
        //        {
        //            returnPatients = 100000;
        //            range = 0;
        //        }
        //        // Convert input color code to hex format to match database column label
        //        List<string> hexColor = new List<string>();
        //        if (color.Count() > 0)
        //        {
        //            foreach (var colorItem in color)
        //            {
        //                hexColor.Add("#" + colorItem.ToLower());
        //            }
        //        }

        //        List<string> brandLower = brand.ConvertAll(x => x.ToLower());
        //        List<string> categoryLower = category.ConvertAll(x => x.ToLower());
        //        List<string> demographicLower = demographic.ConvertAll(x => x.ToLower());
        //        List<string> materialLower = material.ConvertAll(x => x.ToLower());
        //        List<string> typeLower = type.ConvertAll(x => x.ToLower());

        //        // Check that minPrice is not greater than maxPrice and minPrice is non-negative
        //        if (minPrice < 0 || maxPrice < 0)
        //        {
        //            _logger.LogInformation("Prices cannot be negative.");
        //            throw new BadRequestException("Prices cannot be negative.");
        //        }
        //        if (minPrice > maxPrice && !maxPrice.Equals(0))
        //        {
        //            _logger.LogInformation("The minimum price cannot be greater than the maximum price.");
        //            throw new BadRequestException("The minimum price cannot be greater than the maximum price.");
        //        }

        //        try
        //        {
        //            patientsCount = await _patientRepository.GetPatientsCountAsync(active, brandLower, categoryLower, hexColor,
        //                                                         demographicLower, materialLower,
        //                                                         minPrice, maxPrice, typeLower, range, returnPatients);
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError(ex.Message);
        //            throw new ServiceUnavailableException("There was a problem connecting to the database.");
        //        }

        //        return patientsCount;
        //    }
        //}
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
        //public async Task<IEnumerable<Patient>> GetPatientsAsync(Nullable<bool> active, List<string> brand, List<string> category,
        //                                                         List<string> color, List<string> demographic, List<string> material,
        //                                                         decimal minPrice, decimal maxPrice, List<string> type, int? range)
        //{
        //    IEnumerable<Patient> patients;

        //    int returnPatients = 20;
        //    if (range == null)
        //    {
        //        returnPatients = 100000;
        //        range = 0;
        //    }
        //    // Convert input color code to hex format to match database column label
        //    List<string> hexColor = new List<string>();
        //    if (color.Count() > 0)
        //    {
        //        foreach (var colorItem in color)
        //        {
        //            hexColor.Add("#" + colorItem.ToLower());
        //        }
        //    }

        //    // Check that minPrice is not greater than maxPrice and minPrice is non-negative
        //    if (minPrice < 0 || maxPrice < 0)
        //    {
        //        _logger.LogInformation("Prices cannot be negative.");
        //        throw new BadRequestException("Prices cannot be negative.");
        //    }
        //    if (minPrice > maxPrice && !maxPrice.Equals(0))
        //    {
        //        _logger.LogInformation("The minimum price cannot be greater than the maximum price.");
        //        throw new BadRequestException("The minimum price cannot be greater than the maximum price.");
        //    }

        //    // Convert all strings to lowercase for simplified query parameter matching
        //    List<string> brandLower = brand.ConvertAll(x => x.ToLower());
        //    List<string> categoryLower = category.ConvertAll(x => x.ToLower());
        //    List<string> demographicLower = demographic.ConvertAll(x => x.ToLower());
        //    List<string> materialLower = material.ConvertAll(x => x.ToLower());
        //    List<string> typeLower = type.ConvertAll(x => x.ToLower());

        //    try
        //    {
        //        patients = await _patientRepository.GetPatientsAsync(active, brandLower, categoryLower, hexColor,
        //                                                         demographicLower, materialLower,
        //                                                         minPrice, maxPrice, typeLower, range, returnPatients);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        throw new ServiceUnavailableException("There was a problem connecting to the database.");
        //    }

        //    return patients;
        //}
        /// <summary>
        /// Asynchronously updates patient with new patient information
        /// </summary>
        /// <param name="updatedPatient"></param>
        /// <returns> The updated patient</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Patient> UpdatePatientAsync (Patient updatedPatient)
        {
            Patient newPatient;

            Patient existingPatient;
            try
            {
                existingPatient = await _patientRepository.NoTrackingGetPatientByIdAsync(updatedPatient.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (existingPatient == null)
            {
                _logger.LogInformation($"Patient with id: {updatedPatient.Id} does not exist.");
                throw new NotFoundException($"Patient with id:{updatedPatient.Id} not found.");
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
            //List<string> errors = Validation.PatientValidation(updatedPatient);
            //if (errors.Count > 0)
            //{
            //    throw new BadRequestException(string.Join(' ', errors));
            //}
            return newPatient;
        }
        /// <summary>
        /// Persists a purchase to the database.
        /// </summary>
        /// <param name="model">PurchaseDTO used to build the purchase.</param>
        /// <returns>The persisted purchase with IDs.</returns>
        public async Task<Patient> CreatePatientAsync(Patient newPatient)
        {
            Patient savedPatient;


            //List<string> errors = Validation.PatientValidation(newPatient);
            //if (errors.Count > 0)
            //{
            //    throw new BadRequestException(string.Join(' ', errors));
            //}
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
            try
            {
                existingPatient = await _patientRepository.GetPatientByIdAsync(id);
                //purchasedPatient = await CheckForPurchasesByPatientIdAsync(id, existingPatient);
                if (existingPatient == null)
                {
                    _logger.LogInformation($"Patient with id: {id} does not exist.");
                    throw new NotFoundException($"Patient with id:{id} not found.");
                }
                //else if (purchasedPatient)
                //{
                //    _logger.LogInformation($"Patient with id: {id} has purchases associated with it.");
                //    throw new BadRequestException($"Patient with id: {id} has purchases associated with it.");
                //}
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
        /// Helper function for DeletePatientByIdAsync to check for purchases associated with the patient before deleting.
        /// </summary>
        /// <param name="patientId">Id of the patient to be deleted.</param>
        /// <param name="patient">The patient object that will be deleted.</param>
        /// <returns>A patient with purchases or null if there are no purchases.</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        //public async Task<bool> CheckForPurchasesByPatientIdAsync(int patientId, Patient paitent)
        //{
        //    bool purchaseLineItems;
        //    try
        //    {
        //        purchaseLineItems = await _lineItemsRepository.GetLineItemsByPatientIdAsync(patientId);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        throw new ServiceUnavailableException("There was a problem connecting to the database.");
        //    }
        //    return purchaseLineItems;
        //}
    }
}
