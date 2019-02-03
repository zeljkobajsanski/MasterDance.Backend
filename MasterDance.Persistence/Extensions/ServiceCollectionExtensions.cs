using MasterDance.Persistence.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MasterDance.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceModule(this IServiceCollection serviceCollection, string connectionString)
        {
            // Add DbContext using SQL Server Provider
            serviceCollection.AddDbContext<MasterDanceDbContext>(options =>
                options.UseSqlServer(connectionString));
            serviceCollection.AddTransient<IDatabaseQueries, DatabaseQueries>();
            return serviceCollection;
        }
    }
}