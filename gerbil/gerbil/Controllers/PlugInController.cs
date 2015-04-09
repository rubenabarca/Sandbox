namespace gerbil.Controllers
{
    using gerbil.Models;
    using Gerbil;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class PlugInController : Controller
    {
        // GET: PlugIn
        public ActionResult Index()
        {
            var animalLoader = new AnimalProviderLoader();
            var pluginAssemblyPath = Path.Combine(HttpRuntime.AppDomainAppPath, "plugins");
            var availableTypes = animalLoader.GetAnimalProviders(pluginAssemblyPath).ToArray();
            var availableTypeDictionary = new Dictionary<Type, IEnumerable<IAnimal>>();
            foreach (var availableType in availableTypes)
            {
                var animalProvider = Activator.CreateInstance(availableType) as IAnimalProvider;
                var animals = new List<IAnimal>();
                if (animalProvider != null)
                {
                    animals = animalProvider.GetAnimals().ToList();
                    availableTypeDictionary[availableType] = animals;
                }
            }
            return View(new PluginModel() { AvailableAnimalProviders = availableTypeDictionary });
        }
    }
}