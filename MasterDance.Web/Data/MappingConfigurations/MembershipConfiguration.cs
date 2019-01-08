using MasterDance.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Web.Data.MappingConfigurations
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.Property(x => x.Amount).HasColumnType("money");
            builder.HasOne(x => x.Member).WithMany();
            builder.HasMany(x => x.Payments).WithOne(x => x.Membership);
            builder.Property(x => x.Date).HasColumnType("datetime");
        }
    }
}