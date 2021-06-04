using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Search
{
    public class BinarySearch : ISearch
    {
        public int? Search(int[] array, int value)
        {
            int low = 0;
            int high = array.Length;
            
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == value)
                {
                    return mid;
                }else if(array[mid] > value)
                {
                    high = mid - 1;
                }else if(array[mid] < value)
                {
                    low = mid + 1;
                }
            }
            return null;
        }
    }
}
