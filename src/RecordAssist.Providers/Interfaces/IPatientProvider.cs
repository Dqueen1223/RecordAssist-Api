using RecordAssist.Health.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecordAssist.Health.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for patient and encounter related service methods.
    /// </summary>
    public interface IPatientProvider
    {
        Task<Patient> GetPatientByIdAsync(int patientId);
        Task<IEnumerable<Encounter>> GetEncountersByPatientIdAsync(int patientId);

        Task<Encounter> GetEncounterByEncounterIdAsync(int patientId, int encounterId);

        Task<Encounter> GetEncounterByIdAsync(int id);

        Task<Encounter> UpdateEncounterAsync(int patientId, int encounterId, Encounter updatedEncounter);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<IEnumerable<Encounter>> GetAllEncountersAsync();

        Task<Patient> UpdatePatientAsync(int id, Patient updatedPatient);

        Task<Patient> CreatePatientAsync(Patient patient);

        Task<Encounter> CreateEncounterAsync(Encounter encounter);
        Task<Patient> DeletePatientByIdAsync(int id);
    }
}
