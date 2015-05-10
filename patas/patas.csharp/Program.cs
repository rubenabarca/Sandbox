namespace patas.csharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {

        static double ModularExponentiation(double b, double e, double m)
        {
            return Math.Pow(b, e) % m;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ModularExponentiation(5,3,13));
            Console.ReadLine();
        }
    }
}
