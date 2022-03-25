using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product related service methods.
    /// </summary>
    public interface IPatientProvider
    {
        //Task<Patient> NoTrackingGetProductByIdAsync(int productId);
        Task<Patient> GetPatientByIdAsync(int patientId);
        Task<IEnumerable<Encounter>> GetEncountersByPatientIdAsync(int patientId);

        Task<Encounter> GetEncounterByEncounterIdAsync(int patientId, int encounterId);

        ////Task<IEnumerable<Patient>> GetPatientAsync(List<string> Firstname, List<string> LastName, List<string> Ssn,
        ////                                                         List<string> Email, List<string> Street, List<string> City
        //                                               /*          decimal minPrice, decimal maxPrice, List<string> type, int? range*/);
        Task<Encounter> UpdateEncounterAsync(int patientId, int encounterId, Encounter updatedEncounter);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<IEnumerable<Encounter>> GetAllEncountersAsync();

        Task<Patient> UpdatePatientAsync(int id, Patient updatedPatient);
        //Task<int> GetProductsCountAsync(Nullable<bool> active, List<string> brand, List<string> category,
        //                                                         List<string> color, List<string> demographic, List<string> material,
        //                                                         decimal minPrice, decimal maxPrice, List<string> type, int? range);

        //Task<List<string>> GetAllUniqueProductCategoriesAsync();

        //Task<List<string>> GetAllUniquePatientTypesAsync();

        //Task<Patient> GetPatientsAsync();
        Task<Patient> CreatePatientAsync(Patient patient);

        Task<Encounter> CreateEncounterAsync(Encounter encounter);
        Task<Patient> DeletePatientByIdAsync(int id);

        //Task<bool> CheckForPurchasesByPatientIdAsync(int patientId, Patient patient);
    }
}
