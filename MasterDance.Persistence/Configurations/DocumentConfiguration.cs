using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Documents");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.Content, content =>
            {
                content.Property(p => p.Content).HasColumnName("Content");
                content.Property(p => p.ContentType).HasColumnName("ContentType");
                content.Property(p => p.FileName).HasColumnName("FileName");
            });
        }
    }
}