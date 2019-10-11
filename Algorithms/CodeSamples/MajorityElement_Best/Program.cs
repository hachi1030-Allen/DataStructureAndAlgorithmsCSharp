using System;

namespace MajorityElement_Best
{
    /// <summary>
    /// This program is to demonstrate the best algorithm to find the majority element.
    /// A majority element is defined: assume there is an array and 
    /// one of the element's frequency of appearance in the array is more than half of the total account of the array
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = new int[] {0,1,0,0,2,0,3};
            Console.WriteLine("That number is {0}", GetTheNumber(test));
            Console.ReadLine();
        }

        private static int? GetTheNumber(int[] array)
        {
            // initially the guess will be the first element.
            int? guess = array[0];
            int counter = 1;
            for (int i = 1; i < array.Length; i++)
            {
                // start from the second element of the array
                // if the counter == 0
                // then set the current element to be the guess, then go to next element                
                if (counter == 0)
                {
                    guess = array[i];
                    counter = 1;
                    continue;
                }
                // if counter != 0 which means we have a active guess
                // then if current element == the guess value, then counter++
                // if not, counter--;
                if (array[i] == guess)
                {
                    counter++;
                }
                else
                {
                    counter--;
                }
            }
            if (counter >= 1)
            {
                return guess;
            }

            return null;
        }
    }
}
