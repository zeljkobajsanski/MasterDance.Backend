using MasterDance.Domain.Entities;
using MasterDance.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDance.Persistence.Configurations
{
    public class MemberConfiguration 
    {

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Member>();
            builder.Property(x => x.DateOfBirth).HasColumnType("date");
            builder.Property(x => x.JoinedDate).HasColumnType("date");
            builder.OwnsOne(x => x.Father, parent =>
                {
                    parent.Property(p => p.Name).HasColumnName("Father").HasMaxLength(255);
                    parent.Property(p => p.Phone).HasColumnName("FatherPhone").HasMaxLength(255);
                });
            builder
                .OwnsOne(x => x.Mother, parent =>
                {
                    parent.Property(p => p.Name).HasColumnName("Mother").HasMaxLength(255);
                    parent.Property(p => p.Phone).HasColumnName("MotherPhone").HasMaxLength(255);
                });
            builder.Property(x => x.Dance).HasDefaultValue(true);
        }
    }
}