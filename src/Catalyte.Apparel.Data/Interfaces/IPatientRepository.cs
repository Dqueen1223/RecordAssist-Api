using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for Patient repository methods.
    /// </summary>
    public interface IPatientRepository
    {
        Task<Patient> NoTrackingGetPatientByIdAsync(int patientId);

        Task<Patient> NoTrackingCheckConflictingEmail(string patientEmail);
        Task<Patient> GetPatientByIdAsync(int patientId);
        Task<IEnumerable<Encounter>> GetEncountersByPatientIdAsync(int patientId);

        Task<Encounter> GetEncounterByEncounterIdAsync(int patientId, int encounterId);

        Task<Encounter> NoTrackingGetEncounterByEncounterIdAsync(int patientId, int encounterId);
        Task<Encounter> GetEncounterByIdAsync(int id);

        //Task<int> GetPatientsCountAsync(Nullable<bool> active, List<string> brand, List<string> category,
        //                                                         List<string> color, List<string> demographic, List<string> material,
        //                                                         decimal minPrice, decimal maxPrice, List<string> type, int? range, int returnProducts);

        //Task<IEnumerable<Patient>> GetPatientsAsync(List<String> Firstname, List<string> LastName, List<string> Ssn,
        //                                                         List<string> Email, List<string> Street, List<string> City,
        //                                                         List<string> State, List<string> zIPcODE, List<string> Age, List<string> Height, int returnProducts);

        Task<IEnumerable<Patient>> GetPatientsAsync();

        Task<IEnumerable<Encounter>> GetAllEncountersAsync();

        Task<Encounter> CreateEncounterAsync(Encounter newEncounter);
        Task<Patient> UpdatePatientAsync(Patient patient);

        Task<Encounter> UpdateEncounterAsync(Encounter encounter);

        //Task<List<string>> GetAllUniquePatientCategoriesAsync();
        //Task<List<string>> GetAllUniquePatientTypesAsync();

        Task<Patient> CreatePatientAsync(Patient newPatient);

        Task<Patient> DeletePatientByIdAsync(Patient patient);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
    }
}
