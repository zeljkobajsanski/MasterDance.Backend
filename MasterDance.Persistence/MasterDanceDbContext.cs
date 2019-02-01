using System.Reflection;
using MasterDance.Domain.Entities;
using MasterDance.Domain.ValueObjects;
using MasterDance.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Persistence
{
    public class MasterDanceDbContext : DbContext
    {
        public MasterDanceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<MemberGroup> MemberGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            MemberConfiguration.OnModelCreating(modelBuilder);
            
        }
    }
}