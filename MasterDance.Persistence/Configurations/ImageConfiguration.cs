using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("MemberImages");
            builder.OwnsOne(x => x.Blob, blob =>
            {
                blob.Property(p => p.FileName).HasColumnName("FileName");
                blob.Property(p => p.ContentType).HasColumnName("ContentType").HasDefaultValue("image/png");
                blob.Property(p => p.Content).HasColumnName("Content");
            });
        }
    }
}