using MasterDance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.Property(x => x.FirstName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(128);
            builder.OwnsOne(x => x.Contact, contact =>
            {
                contact.Property(p => p.Address).HasColumnName("Address");
                contact.Property(p => p.Email).HasColumnName("Email");
                contact.Property(p => p.Phone).HasColumnName("Phone");
            });
            builder.HasDiscriminator<string>("MemberType")
                   .HasValue<Person>("Person")
                   .HasValue<Member>("Member")
                   .HasValue<Coach>("Coach");
            
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}