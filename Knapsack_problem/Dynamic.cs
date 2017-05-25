using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_problem
{
    internal static class Dynamic
    {
        public static List<int> Solve(int[,] instantion, int b, int[,] knapsack)
        {
            var result = new List<int>();
            int lenght = instantion.GetLength(1);

            for (int i = 1; i <= lenght; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    if (instantion[0, i - 1] > j)
                        knapsack[i, j] = knapsack[i - 1, j];
                    else
                        knapsack[i, j] = Math.Max(knapsack[i - 1, j], knapsack[i - 1, j - instantion[0, i - 1]] + instantion[1, i - 1]);
                }
            }

            return result;
        }
    }
}
