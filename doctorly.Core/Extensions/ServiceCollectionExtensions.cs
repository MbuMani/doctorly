using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using doctorly.Persistence.Extensions;
using doctorly.Core.MappingProfiles;
using doctorly.Core.Handlers;

namespace doctorly.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDoctorlyCore(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Persistence.Constants.ConnectionStringName);

            services.AddDoctorylyPersistence(connectionString);
            services.AddAutoMapper(typeof(ExternalEventContractProfile));
            services.AddHandlers();
        }

        private static void AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<IEventCoreHandler, Handlers.Impl.EventCoreHandler>();
        }
    }
}
