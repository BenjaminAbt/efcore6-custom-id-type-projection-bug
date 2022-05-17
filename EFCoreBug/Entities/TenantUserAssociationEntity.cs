using EFCoreBug.Models;
using System;

namespace EFCoreBug.Entities;

public class TenantUserAssociationEntity
{
    public Guid Id { get; set; }

    public TenantEntity Tenant { get; set; } = null!;
    public PlatformTenantId TenantId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public PlatformUserId UserId { get; set; } = null!;

}
