using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBug.Entities;

public class TenantEntityConfig : IEntityTypeConfiguration<TenantEntity>
{
    public void Configure(EntityTypeBuilder<TenantEntity> b)
    {
        b.ToTable("Tenants");

        b.HasKey(e => e.Id);

        b.Property(e => e.Id)
           .HasConversion(
               v => v.Value,
               v => new Models.PlatformTenantId(v));

        b.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
