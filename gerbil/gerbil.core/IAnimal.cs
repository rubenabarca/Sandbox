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
        string CommonName { get; set; }
        string Kingdom { get; set; }
        string Phylum { get; set; }
        string Class { get; set; }
        string Order { get; set; }
        string Suborder { get; set; }
        string Family { get; set; }
        string Subfamily { get; set; }
        string Genus { get; set; }
        string Species { get; set; }
    }
}
