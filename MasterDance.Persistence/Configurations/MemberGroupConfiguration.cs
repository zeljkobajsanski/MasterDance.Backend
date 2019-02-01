using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class MemberGroupConfiguration : IEntityTypeConfiguration<MemberGroup>
    {
        public void Configure(EntityTypeBuilder<MemberGroup> builder)
        {
            builder.ToTable("Groups");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        }
    }
}