using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features.c12
{
    record FrozenData(long id, string name, int age);

    internal class FrozenDictionaryTest : IFeature
    {
        public void Action()
        {
            var ls = new List<FrozenData>
            {
                new FrozenData(1,"Bela", 33),
                new FrozenData(2,"Jani", 41),
                new FrozenData(3,"Gizi", 19),
            };
            var fLs = FrozenDictionary
                .ToFrozenDictionary(ls, (data) => data.id);

            fLs.TryGetValue(2, out FrozenData? jani);
        }
    }
}
