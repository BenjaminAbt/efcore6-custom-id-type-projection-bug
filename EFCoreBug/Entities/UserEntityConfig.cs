using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBug.Entities;

public class UserEntityConfig : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> b)
    {
        b.ToTable("Users");

        b.HasKey(e => e.Id);

        b.Property(e => e.Id)
           .HasConversion(
               v => v.Value,
               v => new Models.PlatformUserId(v));

        b.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
