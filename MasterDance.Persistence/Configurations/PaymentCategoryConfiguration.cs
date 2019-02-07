using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class PaymentCategoryConfiguration : IEntityTypeConfiguration<PaymentCategory>
    {
        public void Configure(EntityTypeBuilder<PaymentCategory> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Price).HasColumnType("money");
        }
    }
}