namespace gerbil.Models
{
    using Gerbil;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PluginModel
    {
        public Dictionary<Type, IEnumerable<IAnimal>> AvailableAnimalProviders { get; set; }
    }
}