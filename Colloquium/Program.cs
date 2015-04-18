using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Colloquium
{
    class Program
    {
        static void Main(string[] args)
        {
            File result_file = new File("_result.txt");
            result_file.Write("ok");
            Console.Read();
        }
    }
}
