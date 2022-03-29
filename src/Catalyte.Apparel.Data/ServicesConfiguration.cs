using Catalyte.SuperHealth.Data.Context;
using Catalyte.SuperHealth.Data.Interfaces;
using Catalyte.SuperHealth.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalyte.SuperHealth.Data
{
    /// <summary>
    /// This class provides configuration options for services and context.
    /// </summary>
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<SuperHealthCtx>(options =>
                options.UseNpgsql(config.GetConnectionString("CatalyteApparel")));

            services.AddScoped<ISuperHealthCtx>(provider => provider.GetService<SuperHealthCtx>());
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IEncounterRepository, EncounterRepository>();

            return services;

        }

    }

}
