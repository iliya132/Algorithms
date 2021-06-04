using System;

namespace Algorithms.Sort
{
    public class QuickSort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] array)
        {
            if (IsBaseCase(array.Length))
            {
                return BaseCase(array);
            }
            return RecursiveCase(array);
        }

        private bool IsBaseCase(int arrLen)
        {
            return arrLen <= 2;
        }

        private T Max(T a, T b)
        {
            return a.CompareTo(b) >= 0 ? a : b;
        }

        private T Min(T a, T b)
        {
            return a.CompareTo(b) <= 0 ? a : b;
        }

        private T[] BaseSort(T[] arrayOfTwoElements)
        {
            T min = Min(arrayOfTwoElements[0], arrayOfTwoElements[1]);
            T max = Max(arrayOfTwoElements[0], arrayOfTwoElements[1]);
            return new T[] { min, max };
        }

        private T[] BaseCase(T[] array)
        {
            return array.Length < 2 ? array : BaseSort(array);
        }

        private T[] RecursiveCase(T[] array)
        {
            int pivotElementId = array.Length / 2;
            T pivotElement = array[pivotElementId];
            T[] lessThanOrEqualPivotElement = Filter(array, i => i.CompareTo(pivotElement) <= 0, pivotElementId);
            T[] moreThanPivotElement = Filter(array, i => i.CompareTo(pivotElement) > 0);
            return Concat(Sort(lessThanOrEqualPivotElement), pivotElement, Sort(moreThanPivotElement));
        }

        private T[] Filter(T[] array, Func<T, bool> condition, int excludeElement = -1)
        {
            T[] temp = new T[array.Length];
            int resultLength = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]) && i != excludeElement)
                {
                    temp[resultLength++] = array[i];
                }
            }
            return Slice(temp, resultLength);
        }

        private T[] Slice(T[] source, int count, int start = 0)
        {
            T[] res = new T[count - start];
            for (int i = start; i < count; i++)
            {
                res[i - start] = source[i];
            }
            return res;
        }

        private T[] Concat(T[] arr1, T pivot, T[] arr2)
        {
            T[] res = new T[arr1.Length + arr2.Length + 1];
            arr1.CopyTo(res, 0);
            res[arr1.Length] = pivot;
            arr2.CopyTo(res, arr1.Length + 1);
            return res;
        }
    }
}