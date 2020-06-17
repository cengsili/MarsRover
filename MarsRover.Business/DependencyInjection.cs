
using MarsRover.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Bussiness
{
    public class DependencyInjection
    {
        public static ServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IPosition, Position>();
            services.AddScoped<ITerrain, Terrain>();
            services.AddScoped<IRover, Rover>();
            services.AddScoped<IRoverCommandOperation, RoverCommandOperation>();         
            return services.BuildServiceProvider();
        }
    }
}
