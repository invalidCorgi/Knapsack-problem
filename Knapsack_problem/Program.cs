using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_problem
{
    class Program
    {
        static int[,] InstantionGenerator(int n) 
        {
            var rand = new Random();
            var intantion = new int[2,n];
            for (int i = 0; i < intantion.GetLength(1); i++)
            {
                intantion[0, i] = rand.Next(10, 1001);
                intantion[1, i] = rand.Next(100, 10001);
            }

            return intantion;
        }

        static void Main(string[] args)
        {
            int n = 1000, bProc=50, b, sum = 0;
            var instantion = InstantionGenerator(n);
            var dynamic = new Dynamic();
            var bf = new BruteForce();
            var heurestic = new Heurestic();

            for (int i = 0; i < n; i++)
            {
                sum += instantion[0, i];
            }
            b = sum * bProc / 100;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result1 = heurestic.Random(instantion, b);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            sum = 0;
            foreach (var i in result1)
            {
                sum += instantion[1, i];
            }

            watch.Restart();
            var result2 = heurestic.MinWeight(instantion, b);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            sum = 0;
            foreach (var i in result2)
            {
                sum += instantion[1, i];
            }

            watch.Restart();
            var result3 = heurestic.MaxProfit(instantion, b);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            sum = 0;
            foreach (var i in result3)
            {
                sum += instantion[1, i];
            }

            watch.Restart();
            var result4 = heurestic.MaxRatio(instantion, b);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            sum = 0;
            foreach (var i in result4)
            {
                sum += instantion[1, i];
            }

            /*sum = 0;
            foreach (var i in result)
            {
                sum += instantion[0, i];
            }*/

            Console.Read();
        }
    }
}
