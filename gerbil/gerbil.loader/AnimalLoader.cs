namespace Gerbil
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class AnimalProviderLoader
    {
        public IEnumerable<Type> GetAnimalProviders(string pluginPath)
        {
            var assemblyPathArray = Directory.GetFiles(pluginPath, "*.dll");
            foreach (var assemblyPath in assemblyPathArray)
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                var assemblyTypes = assembly.GetTypes();
                var animalProviderTypes = (from assemblyType in assemblyTypes
                                           where assemblyType.GetInterface(typeof(IAnimalProvider).FullName) != null
                                           select assemblyType).ToArray();
                foreach (var animalProviderType in animalProviderTypes)
                {
                    yield return animalProviderType;
                }
            }
        }
    }
}
