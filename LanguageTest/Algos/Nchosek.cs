using LanguageTest.Features;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Algos;

public record ThreeKey(int k1, int k2, int k3);

public class Comparer : IEqualityComparer<ThreeKey>
{
    public bool Equals(ThreeKey? x, ThreeKey? y)
    {
        var xk1 = x.k1 == y.k1 && x.k1 == y.k2 && x.k1 == y.k3;
        var xk2 = x.k2 == y.k1 && x.k2 == y.k2 && x.k2 == y.k3;
        var xk3 = x.k3 == y.k1 && x.k3 == y.k2 && x.k3 == y.k3;

        return false;
    }

    public int GetHashCode([DisallowNull] ThreeKey obj)
    {
        //throw new NotImplementedException();
        return -1;
    }
}

public class Nchosek : IFeature
{
    public void Action()
    {
        var inp = new int[] { 1, 2, 3, 4, 5 };
        var res = new Dictionary<ThreeKey, bool>(new Comparer());

        for (int i = 0; i < inp.Length; i++)
        {
            for (int j = 0; j < inp.Length; j++)
            {
                for (int k = 0; k < inp.Length; k++)
                {
                    res.TryAdd(new ThreeKey(i, j, k), true);
                }
            }
        }
    }
}
