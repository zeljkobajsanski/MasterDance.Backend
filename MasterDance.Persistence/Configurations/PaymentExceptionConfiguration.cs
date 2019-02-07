using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class PaymentExceptionConfiguration : IEntityTypeConfiguration<PaymentException>
    {
        public void Configure(EntityTypeBuilder<PaymentException> builder)
        {
            builder.Property(x => x.Price).HasColumnType("money");
        }
    }
}