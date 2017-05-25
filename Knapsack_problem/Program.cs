using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_problem
{
    class Program
    {
        private static int[,] InstantionGenerator(int n) 
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
            for (int n = 9; n <= 25; n++)
            {
                //int n = 8 + 1 * cos;
                //Console.WriteLine("n: " + n);
                Console.WriteLine("GH4;PD;BF1;BF2");
                for (int attempt = 0; attempt < 25; attempt++)
                {
                    const int bProc = 75;
                    int b, sum = 0;
                    var instantion = InstantionGenerator(n);
                    var instantionCopy = new int[3, n];

                    for (int i = 0; i < n; i++)
                    {
                        sum += instantion[0, i];
                    }
                    b = sum * bProc / 100;

                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    //--------------------------------------------------random

                    /*var result1 = Heurestic.Random(instantion, b);
                    watch.Stop();
                    
                    Console.WriteLine(watch.Elapsed.ToString().Substring(6)); // / 10000);

                    sum = 0;
                    foreach (var i in result1)
                    {
                        sum += instantion[1, i];
                    }*/

                    //-----------------------------------------------weight

                    /*for (int i = 0; i < n; i++)
                    {
                        instantionCopy[0, i] = instantion[0, i];
                        instantionCopy[1, i] = instantion[1, i];
                        instantionCopy[2, i] = i;
                    }

                    watch.Restart();
                    var result2 = Heurestic.MinWeight1(instantionCopy, b);
                    watch.Stop();
                    Console.WriteLine(watch.Elapsed);

                    sum = 0;
                    foreach (var i in result2)
                    {
                        sum += instantion[1, i];
                    }*/
                    //Console.WriteLine(sum);

                    //--------------------------------------------max

                    /*for (int i = 0; i < n; i++)
                    {
                        instantionCopy[0, i] = instantion[0, i];
                        instantionCopy[1, i] = instantion[1, i];
                        instantionCopy[2, i] = i;
                    }

                    watch.Restart();
                    var result3 = Heurestic.MaxProfit(instantionCopy, b);
                    watch.Stop();
                    Console.WriteLine(watch.Elapsed);

                    sum = 0;
                    foreach (var i in result3)
                    {
                        sum += instantion[1, i];
                    }*/
                    //Console.WriteLine(sum);

                    //-------------------------------------------------ratio

                    for (int i = 0; i < n; i++)
                    {
                        instantionCopy[0, i] = instantion[0, i];
                        instantionCopy[1, i] = instantion[1, i];
                        instantionCopy[2, i] = i;
                    }

                    watch.Restart();
                    var result4 = Heurestic.MaxRatio(instantion, b);
                    watch.Stop();
                    //Console.WriteLine(watch.Elapsed.ToString().Substring(6));
                    Console.Write(watch.Elapsed.ToString().Substring(6)+";");

                    /*sum = 0;
                    foreach (var i in result4)
                    {
                        sum += instantion[1, i];
                    }*/
                    //Console.WriteLine(sum);

                    //--------------------------------------------------------dynamic

                    var dynamic = new int[instantion.GetLength(1) + 1, b + 1];

                    watch.Restart();
                    Dynamic.Solve(instantion, b, dynamic);
                    watch.Stop();
                    //Console.WriteLine(watch.Elapsed.ToString().Substring(6));
                    Console.Write(watch.Elapsed.ToString().Substring(6) + ";");
                    //Console.WriteLine(dynamic[instantion.GetLength(1), b]);

                    /*var result5 = new List<int>();
                    int j = b;
                    for (int i = n; i > 0; i--)
                    {
                        if (dynamic[i, j] != dynamic[i - 1, j])
                        {
                            result5.Add(i - 1);
                            j -= instantion[0, i - 1];
                        }
                    }*/

                    //------------------------------------------------------------bf1

                    watch.Restart();
                    var result6 = BruteForce.Bf1(instantion, b);
                    watch.Stop();
                    //Console.WriteLine(watch.Elapsed.ToString().Substring(6));
                    Console.Write(watch.Elapsed.ToString().Substring(6) + ";");

                    /*sum = 0;
                    foreach (var i in result6)
                    {
                        sum += instantion[1, i];
                    }*/
                    //Console.WriteLine(sum);


                    //----------------------------------------------------------bf2

                    BruteForce.max = 0;
                    watch.Restart();
                    var bitResult = BruteForce.Bf2(n - 1, 0, 0, b, instantion,0);
                    watch.Stop();
                    //Console.WriteLine(watch.Elapsed.ToString().Substring(6));
                    Console.Write(watch.Elapsed.ToString().Substring(6));
                    //Console.WriteLine(BruteForce.max);

                    /*var result7 = new List<int>();
                    int r = 0;
                    while (bitResult != 0)
                    {
                        if ((bitResult & 1) == 1)
                            result7.Add(r);
                        bitResult = bitResult >> 1;
                        r++;
                    }*/
                    Console.WriteLine();

                    //Console.Read();
                }
                Console.WriteLine();
            }
            Console.Read();
            
        }
    }
}
