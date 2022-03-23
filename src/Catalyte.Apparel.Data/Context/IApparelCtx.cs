using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Context
{
    /// <summary>
    /// This interface provides an abstraction layer for Super Health Inc. database context.
    /// </summary>
    public interface IApparelCtx
    {

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<ShippingRate> ShippingRates { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Promo> Promos { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}
