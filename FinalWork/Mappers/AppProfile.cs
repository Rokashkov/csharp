using AutoMapper;
using System.Reflection;

namespace App.Mappers
{
    public class AppProfile: Profile
    {
        public AppProfile()
        {
            ApplyMappingsTo(Assembly.GetExecutingAssembly());
            ApplyMappingsFrom(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsTo(Assembly assembly)
        {
            ApplyMappings(assembly, typeof(IMapTo<>), "MappingTo");
        }

        private void ApplyMappingsFrom(Assembly assembly)
        {
            ApplyMappings(assembly, typeof(IMapFrom<>), "MappingFrom");
        }

        private void ApplyMappings(Assembly assembly, Type mappingInterface, string methodName)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == mappingInterface))
                .ToList();

            var mappigInterfaceName = mappingInterface.Name;

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod(methodName)
                    ?? type.GetInterface(mappigInterfaceName)?.GetMethod(methodName);

                methodInfo?.Invoke(instance, new object[] { this });
            }

        }
    }

    
}
