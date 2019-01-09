using MasterDance.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Web.Data.MappingConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.Property(x => x.FirstName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(128);
            builder.OwnsOne(x => x.Contact);
            builder.HasDiscriminator<string>("MemberType")
                   .HasValue<Person>("Person")
                   .HasValue<Member>("Member")
                   .HasValue<Coach>("Coach");
            
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}