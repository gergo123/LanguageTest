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
                if (list.Length == 0) return list;


            }

            // divide
            // conquer - sort
            // merge

        }
    }
}
