namespace Gerbil
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAnimal
    {
        Guid Id { get; set; }
        string SpeciesName { get; set; }
        string CommonName { get; set; }
    }
}
