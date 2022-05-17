using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreWorks.Entities;

public class TenantUserAssociationEntityConfig : IEntityTypeConfiguration<TenantUserAssociationEntity>
{
    public void Configure(EntityTypeBuilder<TenantUserAssociationEntity> b)
    {
        b.ToTable("TenantUserAssociations");

        b.HasKey(e => e.Id);

        b.HasIndex(e => new { e.TenantId, e.UserId })
           .IsUnique();

        b.HasOne(e => e.Tenant)
           .WithMany(e => e.TenantUserAssociations)
           .HasForeignKey(e => e.TenantId);

        b.HasOne(e => e.User)
           .WithMany(e => e.TenantUserAssociations)
           .HasForeignKey(e => e.UserId);
    }
}