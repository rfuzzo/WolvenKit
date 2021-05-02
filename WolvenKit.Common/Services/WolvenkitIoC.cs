using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splat;

namespace WolvenKit.Common
{
    public static class ServiceLocator
    {
        public static class Default
        {
            public static T ResolveType<T>() => Locator.Current.GetService<T>();
        }
    }
}
