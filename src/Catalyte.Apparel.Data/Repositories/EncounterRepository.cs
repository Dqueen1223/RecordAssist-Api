using RecordAssist.Health.Data.Context;
using RecordAssist.Health.Data.Interfaces;
using RecordAssist.Health.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace RecordAssist.Health.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the LineItems repository.
    /// </summary>
    public class EncounterRepository : IEncounterRepository
    {
        private readonly ISuperHealthCtx _ctx;

        public EncounterRepository(ISuperHealthCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> GetEncounterByPatientIdAsync(int PatientId)
        {
            var encounter = await _ctx.Encounters
                .Where(l => l.PatientId == PatientId)
                .AnyAsync();

            return encounter;
        }
        public async Task<Encounter> CreateEncounterAsync(Encounter encounter)
        {
            await _ctx.Encounters.AddAsync(encounter);
            await _ctx.SaveChangesAsync();

            return encounter;
        }
    }
}