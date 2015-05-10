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

        static double GetPiCalc(double k, double n, double l)
        {
            return ModularExponentiation(16.0, n - k, 8 * k + l) / (8 * k + l);
        }

        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            double n = 0.0;
            stopwatch.Start();

            double k = 0.0;
            for (int i = 0; i <= n; i++)
            {
                k += 4 * GetPiCalc(i, n, 1) - 2 * GetPiCalc(i, n, 4) - GetPiCalc(i, n, 5) - GetPiCalc(i, n, 6);
            }

            var integerPart = (int)k;
            k = 16 * (k % integerPart);

            stopwatch.Stop();
            Console.WriteLine("calculated Nth digit of P in {0}: {1}", stopwatch.Elapsed, k);
            Console.ReadLine();
        }
    }
}
