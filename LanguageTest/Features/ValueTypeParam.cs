using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features
{
    internal class ValueTypeParam : IFeature
    {
        public void Action()
        {
            test(123_555);
            test('a');
            test(true);
            test(1d);
            test(1f);
            test(DateTime.Now);
            test(0b_1001_0000);
        }

        public void test(ValueType valueType)
        {
            var isDec = valueType is float || valueType is double;
        }
    }
}
