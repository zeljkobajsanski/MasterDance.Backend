using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class TrainingTypeConfiguration : IEntityTypeConfiguration<TrainingType>
    {
        public void Configure(EntityTypeBuilder<TrainingType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(3);
            builder.Property(x => x.Name).HasMaxLength(32);
            builder.Property(x => x.Price).HasColumnType("money");
        }
    }
}