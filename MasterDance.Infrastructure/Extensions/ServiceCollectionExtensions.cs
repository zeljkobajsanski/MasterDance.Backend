using MasterDance.Application.Interfaces;
using MasterDance.Common;
using Microsoft.Extensions.DependencyInjection;

namespace MasterDance.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection serviceCollection, string rootFolder)
        {
            serviceCollection.AddTransient<IDateTime, MachineDateTime>();
            serviceCollection.AddTransient<IImageService, ImageService>();
            return serviceCollection;
        }
    }
}