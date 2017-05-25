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
                intantion[0, i] = rand.Next(10, 1001);      //weight
                intantion[1, i] = rand.Next(100, 10001);    //value
            }

            return intantion;
        }

        static void Main(string[] args)
        {
            for (int cos = 1; cos <= 7; cos++)
            {

                for (int attempt = 0; attempt < 15; attempt++)
                {
                    int n = 8 + 1 * cos, bProc = 50, b, sum = 0;
                    var instantion = InstantionGenerator(n);
                    var instantionCopy = new int[3, n];

                    for (int i = 0; i < n; i++)
                    {
                        sum += instantion[0, i];
                    }
                    b = sum * bProc / 100;

                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    //var result1 = heurestic.Random(instantion, b);
                    var result1 = Heurestic.Random(instantion, b);
                    watch.Stop();
                    Console.WriteLine("n: " + n);
                    Console.WriteLine(watch.Elapsed.ToString().Substring(6)); // / 10000);

                    sum = 0;
                    foreach (var i in result1)
                    {
                        sum += instantion[1, i];
                    }

                    for (int i = 0; i < n; i++)
                    {
                        instantionCopy[0, i] = instantion[0, i];
                        instantionCopy[1, i] = instantion[1, i];
                        instantionCopy[2, i] = i;
                        //instantionCopy[3, i] = 0;
                    }
                    //Heurestic.Qs(new int[10, 10], 0, 9, 0); //load qs to memory

                    watch.Restart();
                    //var result2 = heurestic.MinWeight(instantionCopy, b);
                    var result2 = Heurestic.MinWeight1(instantionCopy, b);
                    watch.Stop();
                    Console.WriteLine(watch.Elapsed);

                    sum = 0;
                    foreach (var i in result2)
                    {
                        sum += instantion[1, i];
                    }
                    //Console.WriteLine(sum);

                    for (int i = 0; i < n; i++)
                    {
                        instantionCopy[0, i] = instantion[0, i];
                        instantionCopy[1, i] = instantion[1, i];
                        instantionCopy[2, i] = i;
                        //instantionCopy[3, i] = 0;
                    }

                    watch.Restart();
                    //var result3 = heurestic.MaxProfit(instantionCopy, b);
                    var result3 = Heurestic.MaxProfit(instantionCopy, b);
                    watch.Stop();
                    Console.WriteLine(watch.Elapsed);

                    sum = 0;
                    foreach (var i in result3)
                    {
                        sum += instantion[1, i];
                    }
                    //Console.WriteLine(sum);

                    for (int i = 0; i < n; i++)
                    {
                        instantionCopy[0, i] = instantion[0, i];
                        instantionCopy[1, i] = instantion[1, i];
                        instantionCopy[2, i] = i;
                        //instantionCopy[3, i] = 0;
                    }

                    watch.Restart();
                    //var result4 = heurestic.MaxRatio(instantion, b);
                    var result4 = Heurestic.MaxRatio(instantion, b);
                    watch.Stop();
                    Console.WriteLine(watch.Elapsed);

                    sum = 0;
                    foreach (var i in result4)
                    {
                        sum += instantion[1, i];
                    }
                    //Console.WriteLine(sum);

                    var dynamic = new int[instantion.GetLength(1) + 1, b + 1];

                    watch.Restart();
                    Dynamic.Solve(instantion, b, dynamic);
                    watch.Stop();
                    Console.WriteLine(watch.Elapsed);
                    Console.WriteLine(dynamic[instantion.GetLength(1), b]);

                    var result5 = new List<int>();
                    int j = b;
                    for (int i = n; i > 0; i--)
                    {
                        if (dynamic[i, j] != dynamic[i - 1, j])
                        {
                            result5.Add(i - 1);
                            j -= instantion[0, i - 1];
                        }
                    }

                    //var result6 = bf.Bf1(instantion, b);
                    var result6 = BruteForce.Bf1(instantion, b);

                    sum = 0;
                    foreach (var i in result6)
                    {
                        sum += instantion[1, i];
                    }
                    Console.WriteLine(sum);

                    BruteForce.max = 0;
                    var bitResult = BruteForce.Bf2(n - 1, 0, 0, b, instantion,0);
                    Console.WriteLine(BruteForce.max);

                    var result7 = new List<int>();
                    int r = 0;
                    while (bitResult != 0)
                    {
                        if ((bitResult & 1) == 1)
                            result7.Add(r);
                        bitResult = bitResult >> 1;
                        r++;
                    }

                    /*var result7 = BruteForce.Bf2(instantion, n, b);
    
                    sum = 0;
                    foreach (var i in result7)
                    {
                        sum += instantion[1, i];
                    }
                    Console.WriteLine(sum);
    
                    Console.WriteLine();*/
                    //Console.Read();
                }
            }
            Console.Read();
            
        }
    }
}
