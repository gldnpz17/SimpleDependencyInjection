using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDependecyInjectionSystem
{
    internal class RegistryItem
    {
        internal Type Implementation { get; }
        internal Type Abstraction { get; }
        internal bool IsSingleton { get; }

        internal RegistryItem(Type implementation, Type abstraction, bool isSingleton)
        {
            Implementation = implementation;
            Abstraction = abstraction;
            IsSingleton = isSingleton;
        }
    }
}
