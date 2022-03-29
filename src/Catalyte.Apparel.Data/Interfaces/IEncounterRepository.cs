using Catalyte.SuperHealth.Data.Model;
using System.Threading.Tasks;

namespace Catalyte.SuperHealth.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for Encounter repository methods.
    /// </summary>
    public interface IEncounterRepository
    {
        Task<Encounter> CreateEncounterAsync(Encounter newEncounter);
        Task<bool> GetEncounterByPatientIdAsync(int patientId);
    }
}