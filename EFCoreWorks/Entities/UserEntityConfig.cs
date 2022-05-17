using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreWorks.Entities;

public class UserEntityConfig : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> b)
    {
        b.ToTable("Users");

        b.HasKey(e => e.Id);

        b.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
