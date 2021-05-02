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

            /// <summary>
            /// Register an agnostic service
            /// </summary>
            /// <typeparam name="T">The service</typeparam>
            /// <typeparam name="T1">The service implementation</typeparam>
            public static void RegisterType<T, T1>()
            {
                var impl = Activator.CreateInstance<T1>();
                Locator.CurrentMutable.RegisterConstant(impl, typeof(T));
            }
        }
    }
}
