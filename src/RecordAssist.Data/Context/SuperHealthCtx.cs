using RecordAssist.Health.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RecordAssist.Health.Data.Context
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
