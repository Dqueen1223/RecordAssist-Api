using RecordAssist.Health.Data.Model;
using System.Threading.Tasks;

namespace RecordAssist.Health.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for purchase related service methods.
    /// </summary>
    public interface IEncounterProvider
    {

        Task<Encounter> CreateEncounterAsync(Encounter encounter);

    }
}

