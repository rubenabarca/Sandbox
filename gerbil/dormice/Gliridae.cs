namespace Dormice
{
    using Gerbil;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Gliridae : IAnimal
    {
        public Guid Id { get; set; }

        public string CommonName { get; set; }

        public string Kingdom { get; set; }

        public string Phylum { get; set; }

        public string Class { get; set; }

        public string Order { get; set; }

        public string Suborder { get; set; }

        public string Family { get; set; }

        public string Subfamily { get; set; }

        public string Genus { get; set; }

        public string Species { get; set; }

    }
}
