using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features
{
    internal class MergeSort : IFeature
    {
        public void Action()
        {
            (long[] left, long[] right) divide(long[] list)
            {
                var halfIndex = list.Length / 2;
                return (list[..halfIndex], list[halfIndex..]);
            }
            long[] sort(long[] list)
            {
                if (list.Length == 1) return list;

                var merged = new long[list.Length];
                var (left, right) = divide(list);
                left = sort(left);
                right = sort(right);

                var righti = 0;
                var lefti = 0;
                var i = 0;
                while (righti < right.Length && lefti < left.Length)
                {
                    if (left[lefti] < right[righti])
                    {
                        merged[i] = left[lefti++];
                    }
                    else
                    {
                        merged[i] = right[righti++];
                    }
                    i++;
                }

                while (lefti < left.Length)
                {
                    merged[i++] = left[lefti++];
                }
                while (righti < right.Length)
                {
                    merged[i++] = right[righti++];
                }

                return merged;
            }

            var array = new long[] { 1, 51, 2, 4, 79 };
            Console.WriteLine("Unsorted array:");
            Console.WriteLine(string.Join(',', array));
            var sortedArray = sort(array);
            Console.WriteLine("Sorted array:");
            Console.WriteLine(string.Join(',', sortedArray));

            var array1 = new long[] { 79, 88, 77, 44, 55, 11 };
            var sortedArray2 = sort(array1);
            // divide
            // conquer - sort
            // merge

        }
    }
}
