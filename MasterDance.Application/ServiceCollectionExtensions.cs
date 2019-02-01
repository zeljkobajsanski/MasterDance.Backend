using MasterDance.Application.UseCases.Memberships.MembershipCalculation;
using Microsoft.Extensions.DependencyInjection;

namespace MasterDance.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMembershipCalculatorFactory, MembershipCalculatorFactory>();
            return serviceCollection;
        }
    }
}