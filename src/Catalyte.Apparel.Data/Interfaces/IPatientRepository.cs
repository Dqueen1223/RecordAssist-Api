using RecordAssist.Health.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecordAssist.Health.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for Patient and Encounter repository methods.
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

        Task<IEnumerable<Patient>> GetPatientsAsync();

        Task<IEnumerable<Encounter>> GetAllEncountersAsync();

        Task<Encounter> CreateEncounterAsync(Encounter newEncounter);
        Task<Patient> UpdatePatientAsync(Patient patient);

        Task<Encounter> UpdateEncounterAsync(Encounter encounter);

        Task<Patient> CreatePatientAsync(Patient newPatient);

        Task<Patient> DeletePatientByIdAsync(Patient patient);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
    }
}
