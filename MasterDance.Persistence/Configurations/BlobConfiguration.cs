using MasterDance.Domain.Entities;
using MasterDance.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class BlobConfiguration : IEntityTypeConfiguration<Blob>
    {
        public void Configure(EntityTypeBuilder<Blob> builder)
        {
            builder.Property(x => x.FileName).HasMaxLength(255);
            builder.Property(x => x.ContentType).HasMaxLength(32);
            builder.Property(x => x.Content).IsRequired();
        }
    }
}