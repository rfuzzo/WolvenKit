using System;

namespace WolvenKit.RED4.TweakDB.Types
{
    [Flags]
    public enum GroupTag : byte
    {
        None            = 0,
        Abstract        = 1 << 0,
        NotQueryable    = 1 << 1,
        CPO             = 1 << 2,
        Debug           = 1 << 3
    }
}
