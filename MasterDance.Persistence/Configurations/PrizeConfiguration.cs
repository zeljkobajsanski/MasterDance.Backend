using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class PrizeConfiguration : IEntityTypeConfiguration<Prize>
    {
        public void Configure(EntityTypeBuilder<Prize> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
        }
    }
}