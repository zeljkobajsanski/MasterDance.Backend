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
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Prize> Prizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            MemberConfiguration.OnModelCreating(modelBuilder);
            
        }
    }
}