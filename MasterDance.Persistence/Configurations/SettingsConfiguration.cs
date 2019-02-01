using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class SettingsConfiguration : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.Property(x => x.Key).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Value).IsRequired().HasMaxLength(512);
        }
    }
}