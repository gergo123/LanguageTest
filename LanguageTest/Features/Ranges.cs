using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features
{
    internal class Ranges : IFeature
    {
        private readonly int[] arr;

        public Ranges()
        {
            arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        }

        public void Action()
        {
            // indexing
            var thirdItem = arr[3];
            // index from end operator
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/ranges#systemindex
            var lastItem = arr[^1];

            // range operator
            // index start, index end

            // 2nd index from beginig (3rd actual item)
            // 3rd index from last, zero based (4th actual item)
            var sl1 = arr[2..^3];


            var st = 1;
            var end = 2;
            //
            var array = new int[] { 1, 2, 3, 4, 5 };
            var slice1 = array[2..^3];    // array[new Range(2, new Index(3, fromEnd: true))]
            var slice2 = array[..^3];     // array[Range.EndAt(new Index(3, fromEnd: true))]
            var slice7 = array[..2];
            var slice3 = array[2..];      // array[Range.StartAt(2)]
            var slice4 = array[..];       // array[Range.All]
            var slice5 = array[st..end];

            var midpoint = array.Length / 2;
            var left = array[..midpoint];
            var right = array[midpoint..^0];
            var right2 = array[midpoint..];
        }
    }
}
