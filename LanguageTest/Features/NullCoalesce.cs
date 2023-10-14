using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features
{
    public class NullCoalesce : IFeature
    {
        public void Action()
        {
            T1(default, "bbb");
            T2(" ok a");
            try
            {
                Console.WriteLine("Should throw");
                T2(default);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Should throw end");
            }
        }

        public void T1(string? a, string? b)
        {
            var c = default(string?);
            c ??= a ??= b;

            Console.WriteLine($"c should = {b}");
            Console.WriteLine($"c\t = {c}");
        }

        public void T2(string? a)
        {
            var b = default(string?);
            b ??= a ?? throw new Exception("bla");
            Console.WriteLine(b);
        }
    }
}