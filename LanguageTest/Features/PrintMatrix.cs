using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features
{
    public class PrintMatrix : IFeature
    {
        public void Action()
        {
            var matrix = new int[12][];
            Array.Fill(matrix, new int[12]);

            for (int i = 0; i < matrix.Length; i++)
            {
                var row = matrix[i];
                for (var j = 0; j < row.Length; j++)
                {
                    Console.Write(row[j]);
                }
                Console.WriteLine("---");
            }
        }
    }
}
