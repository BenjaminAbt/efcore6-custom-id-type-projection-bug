using System;

namespace EFCoreBug.Models;

public class PlatformUserId : PlatformBaseGuid
{
    public PlatformUserId() : base() { }
    public PlatformUserId(Guid value) : base(value) { }
}
