using Microsoft.Extensions.DependencyInjection;
using DesafioApi2.Infrastructure.Data.WebApi;

namespace DesafioApi2.Host.Middleware
{
    public static class DomainInjectDependence
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<Domain.Juros.IJurosService, Domain.Services.JurosService>();
            services.AddTransient<Domain.WebApi.IDesafioApi1Repository, DesafioApi1Repository>();

            return services;
        }
    }
}
