using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.ToTable("Competitions");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Date).HasColumnType("date");
            builder.Property(x => x.City).HasMaxLength(255);
        }
    }
}