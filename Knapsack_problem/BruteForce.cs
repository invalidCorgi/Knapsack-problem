using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_problem
{
    internal static class BruteForce
    {
        public static int max = 0;
        public static int bitResult = 0;
        
        public static List<int> Bf1(int[,] instantion, int b)
        {
            int n = instantion.GetLength(1);
            var result = new List<int>();

            int i, j, wSum, vSum, vMaxSum = 0, bitResult = 0;

            for (i = 0; i <= (1 << n); i++)
            {
                wSum = vSum = 0;
                for (j = 0; j < n; j++)
                {
                    if (((i >> j) & 1) != 0) 
                    {
                        wSum += instantion[0,j];
                        vSum += instantion[1,j];
                    }
                }
                if ((vSum > vMaxSum) && (wSum <= b))
                {
                    vMaxSum = vSum;
                    bitResult = i;
                }
            }

            i = 0;
            while (bitResult != 0)
            {
                if((bitResult & 1) == 1)
                    result.Add(i);
                bitResult = bitResult >> 1;
                i++;
            }

            return result;
        }

        public static int Bf2(int n, int wSum, int wsum, int b, int[,] instantion, int recursiveBitResult)
        {
            if (wsum > max)
            {
                max = wsum;
                bitResult = recursiveBitResult;
            }
                
            if (n < 0)
                return 0;
            if (wSum + instantion[0,n] <= b)
            {
                Bf2(n - 1, wSum + instantion[0,n], wsum + instantion[1,n], b, instantion, recursiveBitResult + (1 << n));
            }
            Bf2(n - 1, wSum, wsum, b, instantion, recursiveBitResult);

            return bitResult;
        }
    }
}
