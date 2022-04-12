using RecordAssist.Health.Data.Context;
using RecordAssist.Health.Data.Interfaces;
using RecordAssist.Health.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RecordAssist.Health.Data
{
    /// <summary>
    /// This class provides configuration options for services and context.
    /// </summary>
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<SuperHealthCtx>(options =>
                options.UseNpgsql(config.GetConnectionString("RecordAssist")));

            services.AddScoped<ISuperHealthCtx>(provider => provider.GetService<SuperHealthCtx>());
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IEncounterRepository, EncounterRepository>();

            return services;

        }

    }

}
