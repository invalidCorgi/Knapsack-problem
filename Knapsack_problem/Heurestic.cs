using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_problem
{
    internal static class Heurestic
    {
        public static IEnumerable<int> Random(int[,] instantion, int b)
        {
            var result = new List<int>();
            var rand = new Random();
            int sum = 0, iRand;
            while (sum<=b)
            {
                iRand = rand.Next(instantion.GetLength(1));
                if(!result.Contains(iRand))
                    result.Add(iRand);
                else
                    continue;
                sum += instantion[0, iRand];
            }
            if(sum!=b)result.RemoveAt(result.Count-1);

            return result;
        }

        public static IEnumerable<int> MinWeight1(int[,] instantion, int b)
        {
            var result = new List<int>();
            int sum = 0, i = 0;
            Qs(instantion, 0, instantion.GetLength(1) - 1, 0);  //sort by weights
            while (sum <= b)
            {
                result.Add(instantion[2, i]);
                sum += instantion[0, i];
                i++;
            }
            if (sum != b) result.RemoveAt(result.Count - 1);

            return result;
        }

        public static IEnumerable<int> MinWeight2(int[,] instantion, int b)
        {
            var result = new List<int>();
            int sum = 0, i = 0;
            Qs(instantion, 0, instantion.GetLength(1) - 1, 0);  //sort by weights
            while (sum + instantion[0, i] <= b)
            {
                result.Add(instantion[2, i]);
                sum += instantion[0, i];
                i++;
            }

            return result;
        }

        public static IEnumerable<int> MaxProfit(int[,] instantion, int b)
        {
            var result = new List<int>();
            int sum = 0;
            int length = instantion.GetLength(1);
            Qs(instantion, 0, length-1, 1);  //sort by values
            for (int i = length-1 ; i >= 0; i--)
            {
                if (sum + instantion[0, i] < b)
                {
                    result.Add(instantion[2, i]);
                    sum += instantion[0, i];
                }
            }

            return result;
        }

        public static IEnumerable<int> MaxRatio(int[,] instantion, int b)
        {
            int length = instantion.GetLength(1);
            var tempArray = new float[2, length];
            var result = new List<int>();
            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                tempArray[0, i] = i;
                tempArray[1, i] = (float)instantion[1, i] / instantion[0, i];
            }
            QsFloat(tempArray, 0, length - 1, 1);  //sort by ratio
            for (int i = length - 1; i >= 0; i--)
            {
                if (sum + instantion[0, (int) tempArray[0, i]] < b)
                {
                    result.Add((int) tempArray[0, i]);
                    sum += instantion[0, (int)tempArray[0, i]];
                }
            }

            return result;
        }

        private static void Qs(int[,] tab, int left, int right, int param)
        {
            while (true)
            {
                int i = left;
                int j = right;
                int pivot = tab[param, (left + right) / 2];
                while (i < j)
                {
                    while (tab[param, i] < pivot) i++; 
                    while (tab[param, j] > pivot) j--; 
                    if (i <= j)
                    {
                        for (int k = 0; k < tab.GetLength(0); k++)
                        {
                            int temp = tab[k, i];
                            tab[k, i] = tab[k, j];
                            tab[k, j] = temp;
                        }
                        i++;
                        j--;
                    }
                }
                if (left < j) Qs(tab, left, j, param);
                if (i < right)
                {
                    left = i;
                    continue;
                }
                break;
            }
        }

        private static void QsFloat(float[,] tab, int left, int right, int param)
        {
            while (true)
            {
                int i = left;
                int j = right;
                float pivot = tab[param, (left + right) / 2]; 
                while (i < j) 
                {
                    while (tab[param, i] < pivot) i++; 
                    while (tab[param, j] > pivot) j--; 
                    if (i <= j)
                    {
                        for (int k = 0; k < tab.GetLength(0); k++)
                        {
                            float temp = tab[k, i];
                            tab[k, i] = tab[k, j];
                            tab[k, j] = temp;
                        }
                        i++; 
                        j--;
                    }
                }
                if (left < j) QsFloat(tab, left, j, param);
                if (i < right)
                {
                    left = i;
                    continue;
                }
                break;
            }
        }
    }
}
