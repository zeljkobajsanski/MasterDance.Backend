using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasOne(x => x.Membership).WithMany(x => x.Payments);
            builder.Property(x => x.Amount).HasColumnType("money");
            builder.Property(x => x.Date).HasColumnType("datetime");
            builder.HasOne(x => x.Creator).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}