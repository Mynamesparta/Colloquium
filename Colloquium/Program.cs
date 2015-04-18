using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Colloquium
{
    public struct Point
    {
        public float x, y, z;
    }
    class Program
    {
        static void Main(string[] args)
        {
            File input_file = new File("input.txt");
            //input_file.Write("hello");
            //Console.Write(input_file.Read());
            List<Point> list_of_point = new List<Point>();
            input_file.readPoint(ref list_of_point);
            Console.WriteLine("===");
            foreach (Point point in list_of_point)
            {
                Console.WriteLine(point.x + " " + point.y + " " + point.z);
            }
            //
            Console.Read();
        }
    }
}
