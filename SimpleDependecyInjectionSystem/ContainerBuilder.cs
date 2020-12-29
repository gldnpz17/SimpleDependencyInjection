using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDependecyInjectionSystem
{
    /// <summary>
    /// A builder class for the DI container.
    /// </summary>
    public class ContainerBuilder
    {
        private IContainer _container = new Container();

        /// <summary>
        /// Registers the types for the DI container.
        /// </summary>
        public void Register(Type implementation, Type abstraction, bool isSingleton)
        {
            _container.RegisterType(implementation, abstraction, isSingleton);
        }

        /// <summary>
        /// Returns the DI container.
        /// </summary>
        /// <returns>The DI container constrcuted</returns>
        public IContainer Build()
        {
            return _container;
        }
    }
}
