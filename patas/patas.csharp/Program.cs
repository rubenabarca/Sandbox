namespace patas.csharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {

        static double ModularExponentiationDirect(double b, double e, double m)
        {
            return Math.Pow(b, e) % m;
        }

        static double ModularExponentiation(double b, double e, double m)
        {
            var c = 1.0;
            for (int k = 0; k < e; k++)
            {
                c = (b * c) % m;
            }
            return c;
        }

        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            double b = 18.0, e = 36.0, m = 497.0;
            stopwatch.Start();
            var c = ModularExponentiationDirect(b, e, m);
            stopwatch.Stop();
            Console.WriteLine("calculated modular exponentiation directly in {0}: {1}", stopwatch.Elapsed, c);
            stopwatch.Reset();
            stopwatch.Start();
            c = ModularExponentiation(b, e, m);
            stopwatch.Stop();
            Console.WriteLine("calculated modular exponentiation alternate method in {0}: {1}", stopwatch.Elapsed, c);
            Console.ReadLine();
        }
    }
}
