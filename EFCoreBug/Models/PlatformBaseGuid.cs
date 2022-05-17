using System;

namespace EFCoreBug.Models;

public abstract class PlatformBaseGuid
{
    public PlatformBaseGuid() { }
    public PlatformBaseGuid(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; set; }
    public string Format(string format) => Value.ToString(format);
}
