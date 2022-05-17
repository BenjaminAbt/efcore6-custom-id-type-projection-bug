using EFCoreBug.Models;
using System.Collections.Generic;

namespace EFCoreBug.Entities;

public class TenantEntity
{
    public PlatformTenantId Id { get; set; } = null!;
    public string Name = null!;

    public ICollection<TenantUserAssociationEntity> TenantUserAssociations { get; set; }
        = new List<TenantUserAssociationEntity>();
}
