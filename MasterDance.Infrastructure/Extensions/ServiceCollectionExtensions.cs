using MasterDance.Common;
using Microsoft.Extensions.DependencyInjection;

namespace MasterDance.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDateTime, MachineDateTime>();
            return serviceCollection;
        }
    }
}