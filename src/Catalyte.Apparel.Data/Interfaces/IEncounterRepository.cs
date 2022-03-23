using System.Threading.Tasks;
using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.Data.Interfaces
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