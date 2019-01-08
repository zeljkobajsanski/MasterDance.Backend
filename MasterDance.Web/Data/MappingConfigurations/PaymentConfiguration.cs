using MasterDance.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Web.Data.MappingConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne(x => x.Membership).WithMany(x => x.Payments);
            builder.Property(x => x.Amount).HasColumnType("money");
            builder.Property(x => x.Date).HasColumnType("datetime");
        }
    }
}