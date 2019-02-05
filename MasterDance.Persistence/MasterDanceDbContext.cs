using System.Reflection;
using MasterDance.Domain.Entities;
using MasterDance.Domain.ValueObjects;
using MasterDance.Persistence.Configurations;
using MasterDance.Persistence.QueryTypes;
using Microsoft.EntityFrameworkCore;
using Evidence = MasterDance.Domain.Entities.Evidence;

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
        public DbQuery<GetDebtList> GetDebtList { get; set; }
        public DbQuery<MembershipsAndPayments> MembershipsAndPayments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Evidence> Evidences { get; set; }
        public DbQuery<QueryTypes.Evidence> EvidencesQuery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            MemberConfiguration.Configure(modelBuilder);
            DocumentConfiguration.Configure(modelBuilder);
        }
    }
}