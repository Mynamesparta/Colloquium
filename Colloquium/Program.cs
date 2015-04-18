using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Colloquium
{
    public struct Point
    {
        public double x, y, z;
    }
    class Program
    {
        static void Main(string[] args)
        {
            File input_file = new File("input.txt");
            File output_file = new File("output.txt");
            //input_file.Write("hello");
            //Console.Write(input_file.Read());
            List<Point> list_of_point = new List<Point>();
            input_file.readPoint(ref list_of_point);
            output_file.writePoint(list_of_point);
            //
            Console.Read();
        }
    }
}
