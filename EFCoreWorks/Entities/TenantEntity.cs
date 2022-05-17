﻿using System;
using System.Collections.Generic;

namespace EFCoreWorks.Entities;

public class TenantEntity
{
    public Guid Id { get; set; }
    public string Name = null!;

    public ICollection<TenantUserAssociationEntity> TenantUserAssociations { get; set; }
        = new List<TenantUserAssociationEntity>();
}
