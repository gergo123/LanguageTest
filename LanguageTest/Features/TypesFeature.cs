using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features
{
    internal class TypesFeature
    {
        public void test(ValueType valueType)
        {
            var isDec = valueType is float || valueType is double;
        }
    }
}
