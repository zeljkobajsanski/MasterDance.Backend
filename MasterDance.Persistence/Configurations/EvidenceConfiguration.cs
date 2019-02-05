using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class EvidenceConfiguration: IEntityTypeConfiguration<Evidence>
    {
        public void Configure(EntityTypeBuilder<Evidence> builder)
        {
            builder.Property(x => x.Date).HasColumnType("date");
            builder.HasOne(x => x.Member).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Coach).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}