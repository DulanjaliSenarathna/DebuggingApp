using System;
using System.Collections.Generic;

namespace DebuggingApp
{
    class Program
    {
       public static void Main(string[] args)
        {
            var numbers = new List<int>() {1,2,3,4,5,6 };
            var smallest = GetSmallests(numbers, 3);

            foreach(var number in smallest)//if we iterate over original list(numbers), we can get output 4,5,6. it means list remove first 3 numbers. this is a side effect.
            {
                Console.WriteLine(number);
            }
        }

        public static List<int> GetSmallests(List<int> list, int count)
        {
            var buffer = new List<int>(list);//create a copy of the list and do processing by it.
            var smallests = new List<int>();

            while (smallests.Count < count)
            {
                var min = GetSmallest(buffer);
                smallests.Add(min);
                buffer.Remove(min);//now check original list, it contains all 6 numbers.
            }

            return smallests;
        }

        private static int GetSmallest(List<int> list)
        {
            //Assume the first number is the smallest
            var min = list[0];

            for (var i = 1; i < list.Count; i++)
            {
                if (list[i] < min)
                {
                    min = list[i];
                }
               
            }
            return min;
        }
    }
}
