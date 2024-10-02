using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPSLS.Data.Choices;
using RPSLS.Data.Computers;
using RPSLS.Data.Plays;
using System.Diagnostics.CodeAnalysis;

namespace RPSLS.Data.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceDataLayerExtension
    {
        public static void AddServiceDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = ConnectionStringProvider.GetConnectionString(configuration);
            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseNpgsql(connString);
            });
  
            services.AddScoped<IChoiceRepository, ChoiceRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IComputerRepository, ComputerRepository>();
        }
    }
}