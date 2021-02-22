using CalculatorService.Server.Services;
using CalculatorService.Server.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorService.Server.Configuration
{

    public static class ServiceCollectionExtensions
    {

        public static void AddCalculatorServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMathService, MathService>();
            services.AddSingleton<IPersistenceService, PersistenceService>();
        }

    }
}
