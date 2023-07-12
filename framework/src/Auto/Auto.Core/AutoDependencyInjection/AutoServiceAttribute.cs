using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Core.AutoDependencyInjection
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoServiceAttribute : Attribute
    {
        public readonly ServiceLifetime Lifetime;

        public AutoServiceAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            Lifetime = lifetime;
        }
    }
}