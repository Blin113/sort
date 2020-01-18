using System;
using System.Collections.Generic;
using System.Text;

namespace sorting
{
    public static class MergeSorter
    {
        public static void DoMergeSort(this int[] num)
        {
            var sortedNumbers = MergeSort(num);
            
            for(int i = 0; i < sortedNumbers.Length; i++)
            {
                num[i] = sortedNumbers[i];
            }
        }

        private static int[] MergeSort(int[] num)
        {
            if (num.Length <= 1) return num;

            var left = new list<int>();
            var right = new list<int>();

            for (int i = 0; i < num.Length; i++)
            {
                if (i % 2 > 0)
                {
                    left.Add(num[i]);
                }
                else
                {
                    right.Add(num[i]);
                }
            }

            left = MergeSort(left.ToArray()).ToList();
            right = MergeSort(right.ToArray()).ToList();

            return Merge(left, right);
        }

        private static int[] Merge(list<int> left, list<int> right)
        {
            var result = new List<int>();

            while (NotEmpty(left) && NotEmpty(right))
            {
                if (left.First() <= right.First())
                {
                    MoveValueFromSourceToResult(left, result);
                }
                else
                {
                    MoveValueFromSourceToResult(right, result);
                }
            }

            while (NotEmpty(left))
            {
                MoveValueFromSourceToResult(left, result);
            }

            while (NotEmpty(right))
            {
                MoveValueFromSourceToResult(right, result);
            }

            return result.ToArray;
        }

        private static bool NotEmpty(list<int> list)
        {
            return list.Count > 0;
        }

        private static void MoveValueFromSourceToResult(list<int> list, List<int> result)
        {
            result.Add(list.First());
            list.RemoveAt(0);
        }
    }
}
