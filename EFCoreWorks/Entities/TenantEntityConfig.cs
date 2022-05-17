using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreWorks.Entities;

public class TenantEntityConfig : IEntityTypeConfiguration<TenantEntity>
{
    public void Configure(EntityTypeBuilder<TenantEntity> b)
    {
        b.ToTable("Tenants");

        b.HasKey(e => e.Id);

        b.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
