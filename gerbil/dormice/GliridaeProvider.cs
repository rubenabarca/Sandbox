namespace Dormice
{
    using Gerbil;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GliridaeProvider: IAnimalProvider
    {
        public IEnumerable<IAnimal> GetAnimals()
        {
            yield return new Gliridae() 
            {
                CommonName = "African dormouse",
                Class = "Mammalia",
                Family = "Gliridae",
                Genus = "Graphiurus",
                Id = new Guid("1E52006F-F4F8-4D4B-8A84-B0F3AA0E61D1"),
                Kingdom = "Animalia",
                Order = "Rodentia",
                Phylum = "Chordata",
                Species = "Graphiurus angolensis",
                Subfamily = "Graphiurinae",
                Suborder = "Sciuromorpha",
            };
        }
    }
}
