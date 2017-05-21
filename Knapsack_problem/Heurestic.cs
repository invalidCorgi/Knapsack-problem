using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_problem
{
    class Heurestic
    {
        public List<int> Random(int[,] instantion, int b)
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

        public List<int> MinWeight(int[,] instantion, int b)
        {
            var result = new List<int>();
            int sum = 0, min, indexMin=0;
            while (sum <= b)
            {
                min = 1001;
                for (int i = 0; i < instantion.GetLength(1); i++)
                {
                    if (instantion[0, i] < min && !result.Contains(i))
                    {
                        min = instantion[0, i];
                        indexMin = i;
                    }
                }
                result.Add(indexMin);
                sum += instantion[0, indexMin];
            }
            if (sum != b) result.RemoveAt(result.Count - 1);

            return result;
        }

        public List<int> MaxProfit(int[,] instantion, int b)
        {
            var result = new List<int>();
            int sum = 0, max, indexMax = 0;
            while (sum <= b)
            {
                max = 0;
                for (int i = 0; i < instantion.GetLength(1); i++)
                {
                    if (instantion[1, i] > max && !result.Contains(i))
                    {
                        max = instantion[1, i];
                        indexMax = i;
                    }
                }
                result.Add(indexMax);
                sum += instantion[0, indexMax];
            }
            if (sum != b) result.RemoveAt(result.Count - 1);

            return result;
        }

        public List<int> MaxRatio(int[,] instantion, int b)
        {
            var result = new List<int>();
            var temp = new List<float>();
            int sum = 0, indexMax = 0;
            float max;

            for (int i = 0; i < instantion.GetLength(1); i++)
            {
                temp.Add((float)instantion[1, i] / instantion[0, i]);
            }
            while (sum <= b)
            { 
                max = 0;
                for (int i = 0; i < instantion.GetLength(1); i++)
                {
                    if (temp[i] > max && !result.Contains(i))
                    {
                        max = temp[i];
                        indexMax = i;
                    }
                }
                result.Add(indexMax);
                sum += instantion[0, indexMax];
            }
            if (sum != b) result.RemoveAt(result.Count - 1);

            return result;
        }
    }
}
