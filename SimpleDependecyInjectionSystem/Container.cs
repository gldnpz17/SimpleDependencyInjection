using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace SimpleDependecyInjectionSystem
{
    public class Container : IContainer
    {
        private readonly List<RegistryItem> _registry = new List<RegistryItem>();
        private readonly List<object> _singletons = new List<object>();

        public Container()
        {
            _singletons.Add(this);
        }

        public void RegisterType(Type implementation, Type abstraction, bool isSingleton)
        {
            _registry.Add(new RegistryItem(implementation, abstraction, isSingleton));
        }

        public T GetInstance<T>()
        {
            // Get registry entry.
            List<RegistryItem> entries = (from regEntry in _registry
                                          where regEntry.Abstraction == typeof(T)
                                          select regEntry).ToList();
            if (entries.Count == 0) // If there are no entries in the registry.
            {
                // Throw exception.
                throw new Exception($"Entry not found for type : {typeof(T)}.");
            }
            else
            {
                // Get the entry.
                RegistryItem entry = entries.First();

                if (entry.IsSingleton) // If a singleton is requested.
                {
                    // Get instance.
                    List<object> outputList = (from output in _singletons
                                               where output.GetType() == entry.Implementation
                                               select output).ToList();
                    if (outputList.Count == 0) // If there is no singleton instance to return.
                    {
                        // Instantiate a new instance.
                        T output = GetInstanceRecursive(entry);

                        _singletons.Add(output);
                        return output;
                    }
                    else
                    {
                        return (T)outputList.First();
                    }
                }
                else
                {
                    return GetInstanceRecursive(entry);
                }
            }

            T GetInstanceRecursive(RegistryItem registryItem)
            {
                // Get constructors.
                List<ConstructorInfo> constructorInfos = registryItem.Implementation.GetConstructors().ToList();
                
                // Select the one with the most parameters.
                int maxParamCount = 0;
                ConstructorInfo selectedConstructor = constructorInfos[0]; // In case there aren't any, select the default constructor.
                foreach (var item in constructorInfos)
                {
                    if (item.GetParameters().ToList().Count > maxParamCount)
                    {
                        maxParamCount = item.GetParameters().ToList().Count;
                        selectedConstructor = item;
                    }
                }
                
                // Get the required arguments.
                List<ParameterInfo> parameterInfos = selectedConstructor.GetParameters().ToList();
                
                // Instantiate the arguments.
                List<object> args = new List<object>();
                foreach (ParameterInfo item in parameterInfos)
                {
                    Type itemType = item.ParameterType;
                    MethodInfo methodInfo = GetType().GetMethod("GetInstance").MakeGenericMethod(itemType);
                    args.Add(methodInfo.Invoke(this, null));
                }

                // Instantiate.
                return (T)Activator.CreateInstance(registryItem.Implementation, args.ToArray());
            }
        }
    }
}
