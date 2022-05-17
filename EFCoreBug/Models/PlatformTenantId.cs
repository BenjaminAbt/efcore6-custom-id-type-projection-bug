using System;

namespace EFCoreBug.Models;

public class PlatformTenantId : PlatformBaseGuid
{
    public PlatformTenantId() : base() { }
    public PlatformTenantId(Guid value) : base(value) { }
}
