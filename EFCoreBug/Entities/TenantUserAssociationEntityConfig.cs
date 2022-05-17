using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBug.Entities;

public class TenantUserAssociationEntityConfig : IEntityTypeConfiguration<TenantUserAssociationEntity>
{
    public void Configure(EntityTypeBuilder<TenantUserAssociationEntity> b)
    {
        b.ToTable("TenantUserAssociations");

        b.HasKey(e => e.Id);

        b.HasIndex(e => new { e.TenantId, e.UserId })
           .IsUnique();

        b.Property(e => e.TenantId)
           .HasConversion(
               v => v.Value,
               v => new Models.PlatformTenantId(v));

        b.Property(e => e.UserId)
           .HasConversion(
               v => v.Value,
               v => new Models.PlatformUserId(v));

        b.HasOne(e => e.Tenant)
           .WithMany(e => e.TenantUserAssociations)
           .HasForeignKey(e => e.TenantId);

        b.HasOne(e => e.User)
           .WithMany(e => e.TenantUserAssociations)
           .HasForeignKey(e => e.UserId);
    }
}