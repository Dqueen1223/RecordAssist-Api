using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Catalyte.SuperHealth.Data.Model;

namespace Catalyte.SuperHealth.Data.Context
{
    /// <summary>
    /// Apparel database context provider.
    /// </summary>
    public class SuperHealthCtx : DbContext, ISuperHealthCtx
    {

        public SuperHealthCtx(DbContextOptions<SuperHealthCtx> options) : base(options)
        { }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Encounter> Encounters { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
