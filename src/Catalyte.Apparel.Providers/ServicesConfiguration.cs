using RecordAssist.Health.Providers.Interfaces;
using RecordAssist.Health.Providers.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace RecordAssist.Health.Providers
{
    /// <summary>
    /// This class provides configuration options for provider services.
    /// </summary>
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IPatientProvider, PatientProvider>();
            services.AddScoped<IEncounterProvider, EncounterProvider>();

            return services;
        }
    }
}
