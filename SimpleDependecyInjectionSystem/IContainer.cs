using System;

namespace SimpleDependecyInjectionSystem
{
    /// <summary>
    /// A simple IoC container by gldnpz17.
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Registers the type pairings for the container.
        /// </summary>
        /// <param name="implementation">The type of the returned instance.</param>
        /// <param name="abstraction">The type of the instance requested.</param>
        /// <param name="isSingleton">Whether or not a singleton is returned.</param>
        void RegisterType(Type implementation, Type abstraction, bool isSingleton);

        /// <summary>
        /// Gets an instance of type T.
        /// </summary>
        /// <typeparam name="T">The requested instance's type.</typeparam>
        /// <returns>An instance of type T</returns>
        T GetInstance<T>();
    }
}