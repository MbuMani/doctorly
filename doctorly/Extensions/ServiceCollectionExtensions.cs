using doctorly.Core.Extensions;

namespace doctorly.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDoctorlyCore(configuration);
        }
    }
}
