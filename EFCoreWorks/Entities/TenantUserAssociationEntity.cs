using System;

namespace EFCoreWorks.Entities;

public class TenantUserAssociationEntity
{
    public Guid Id { get; set; }

    public TenantEntity Tenant { get; set; } = null!;
    public Guid TenantId { get; set; }
    public UserEntity User { get; set; } = null!;
    public Guid UserId { get; set; }

}
