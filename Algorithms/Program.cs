using Algorithms.Search;

using System;

namespace Algorithms
{
    class Program
    {
        static int[] testArray = { 100, 4, 93, 94, 98, 71, 12, 86, 66, 28, 55, 86, 41, 45, 56, 92 };
        static void Main(string[] args)
        {
            Sort.QuickSort<int> sort = new Sort.QuickSort<int>();
            int[] result = sort.Sort(testArray);
            System.Console.WriteLine($"initial array: {string.Join(", ", testArray)}");
            System.Console.WriteLine($"Final array: {string.Join(", ", result)}");
            
        }
    }
}
