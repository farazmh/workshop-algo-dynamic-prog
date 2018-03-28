// https://www.hackerrank.com/challenges/coin-change/problem
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static string matrixKey(long a, long b)
    {
        return a + "," + b;
    }

    static long getWays(long total, long[] allNums)
    {
        Dictionary<string, long> matrix = new Dictionary<string, long>();
        for (int i = 0; i < allNums.Length; i++)
        {
            for (int j = 1; j <= total; j++)
            {
                long number = allNums[i];
                long target = j;

                long prevPoint = 0;
                if (i > 0)
                {
                    prevPoint = matrix[matrixKey(allNums[i - 1], target)];
                }

                if (target == number)
                {
                    matrix.Add(matrixKey(number, target), prevPoint + 1);
                }
                else if (target < number || target - number < 0)
                {
                    matrix.Add(matrixKey(number, target), prevPoint + 0);
                }
                else if (target - number > 0 && matrix.ContainsKey(matrixKey(number, target - number)))
                {
                    matrix.Add(matrixKey(number, target), prevPoint + matrix[matrixKey(number, target - number)] + 0);
                }
            }
        }
        return matrix[matrixKey(allNums[allNums.Length - 1], total)];
    }

    static void Main(string[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');
        long[] c = Array.ConvertAll(c_temp, Int64.Parse);
        long ways = getWays(n, c);
        Console.WriteLine(ways);
    }
}
