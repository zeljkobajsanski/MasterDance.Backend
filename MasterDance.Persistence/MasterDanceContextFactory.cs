using MasterDance.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Persistence
{
    public class MasterDanceContextFactory : DesignTimeDbContextFactoryBase<MasterDanceDbContext>
    {
        protected override MasterDanceDbContext CreateNewInstance(DbContextOptions<MasterDanceDbContext> options)
        {
            return new MasterDanceDbContext(options);
        }
    }
}