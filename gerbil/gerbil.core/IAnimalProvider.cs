namespace Gerbil
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAnimalProvider
    {
        IEnumerable<IAnimal> GetAnimals();
    }
}
