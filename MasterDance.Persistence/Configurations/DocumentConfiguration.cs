using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace MasterDance.Persistence.Configurations
{
    public static class DocumentConfiguration
    {
        public static ModelBuilder Configure(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Document>();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ExpirationDate).HasColumnType("date");
            builder.OwnsOne(x => x.Content, c =>
            {
                c.Property(p => p.Content).HasColumnName("Content");
                c.Property(p => p.ContentType).HasColumnName("ContentType").HasMaxLength(255);
                c.Property(p => p.FileName).HasColumnName("FileName").HasMaxLength(255);
            });
            
            return modelBuilder;
        }
    }
}