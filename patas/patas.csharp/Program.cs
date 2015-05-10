namespace patas.csharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            var a = (double)(1 + 1 / Math.Sqrt(2)) / 2;
            var c = (double)(1 / (8 * a));
            var s = (double)Math.Pow(a, 2);
            var f = (double)1.0;
            var precision = 1e-99999;
            while (Math.Abs(c) > precision)
            {
                a = (a + Math.Sqrt((a - c) * (a + c))) / 2.0;
                c = (Math.Pow(c, 2)) / (4.0 * a);
                f = 2.0 * f;
                s = s - (f * Math.Pow(c, 2.0));
            }
            Console.WriteLine((2.0 * Math.Pow(a, 2.0)) / ((2.0 * s) - 1.0));
            Console.ReadLine();
        }
    }
}
