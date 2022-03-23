using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the LineItems repository.
    /// </summary>
    public class EncounterRepository : Interfaces.IEncounterRepository
    {
        private readonly IApparelCtx _ctx;

        public EncounterRepository(IApparelCtx ctx)
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