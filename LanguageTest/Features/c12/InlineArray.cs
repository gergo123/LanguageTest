using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features.c12;

[InlineArray(3)]
public struct ThreeFloats
{
    private float element;
}

// https://endjin.com/blog/2024/11/csharp-12-inline-arrays?utm_source=newsletter.csharpdigest.net&utm_medium=newsletter&utm_campaign=c-12-0-inline-arrays
internal class InlineArray : IFeature
{
    private ThreeFloats xyz;
    public void Action()
    {
        // Array (and strings) take a unknown amount of space in heap. Object has a length after header data which tells how big the object is. All other objects are fixed in length

        xyz[0] = 1;
        xyz[1] = 2;
        xyz[2] = 13;
    }
}
