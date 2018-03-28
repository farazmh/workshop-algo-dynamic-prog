//https://www.hackerrank.com/challenges/equal/problem
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static int equal(int[] arr)
    {
        int counter = 0;
        bool isDone = false;
        List<int> numbersInPlay = new List<int>() { 1, 3, 5 };
        Array.Sort(arr);
        while (!isDone)
        {
            int maxIndex = Array.IndexOf(arr, arr.Max());
            int minIndex = Array.IndexOf(arr, arr.Min());

            int diff = Math.Abs(arr[maxIndex] - arr[minIndex]);
            List<int> candidates = new List<int>() { Math.Abs(diff - numbersInPlay[0]), Math.Abs(diff - numbersInPlay[1]), Math.Abs(diff - numbersInPlay[2]) };
            int candidate = numbersInPlay[Array.IndexOf(candidates.ToArray(), candidates.Min())];
            counter++;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != maxIndex)
                {
                    arr[i] += candidate;
                }
            }

            if (arr.Distinct().Count() == 1)
            {
                isDone = true;
            }
        }
        return counter;
    }

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
            int result = equal(arr);
            Console.WriteLine(result);
        }
    }
}
