using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for Encounter repository methods.
    /// </summary>
    public interface IEncounterRepository
    {
        Task<bool> GetEncounterByPatientIdAsync(int patientId);
    }
}