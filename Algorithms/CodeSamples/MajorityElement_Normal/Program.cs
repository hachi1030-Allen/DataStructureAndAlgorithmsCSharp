using System;
using System.Collections.Generic;
using System.Collections;

namespace FindNumFrequencyMoreThanHalfArraySize_Normal
{
    /// <summary>
    /// This program is a demonstration on a normal algorithm which requies:
    /// There is an array, all the elements are number. 
    /// How to find the number whose frequency of appearance in the array is more than half of the total account of the array. 
    /// Assume that there is definitely a number that matches  this condition.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[]{1,2,1,3,1};
            Console.WriteLine("The number is {0}", GetTheNumber(array));
        }

        private static int? GetTheNumber(int[] array)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (dic.ContainsKey(array[i]))
                {
                    dic[array[i]]++;
                }
                else
                {
                    dic.Add(array[i], 1);
                }
            }
            // Can use LINQ but I choose to implement the logic here.
            foreach (KeyValuePair<int, int> item in dic)
            {
                if (item.Value > (int)(array.Length / 2))
                {
                    return item.Key;
                }
            }
            return null;
        }
    }
}
