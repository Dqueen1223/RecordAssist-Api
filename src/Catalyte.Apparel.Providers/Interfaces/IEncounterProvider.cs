using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for purchase related service methods.
    /// </summary>
    public interface IEncounterProvider
    {
        //Task<IEnumerable<Encounter>> GetAllEncountersByEmailAsync(string email);

        Task<Encounter> CreateEncounterAsync(Encounter encounter);

        //Task<string> CheckForPatientsWithoutEncountersAsync(int id);
    }
}

