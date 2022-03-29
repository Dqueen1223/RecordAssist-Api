using Catalyte.SuperHealth.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Catalyte.SuperHealth.Data.Context
{
    /// <summary>
    /// This interface provides an abstraction layer for Super Health Inc. database context.
    /// </summary>
    public interface ISuperHealthCtx
    {

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Encounter> Encounters { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}
