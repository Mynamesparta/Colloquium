using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Colloquium
{
    public class Point
    {
        public double x, y, z;
        public Point(double _x, double _y, double _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        public Point() { }
    }
    public struct Verge
    {
        public Point a, b, c;
        public Point norm;
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
            //=========================algorithm===============
            int i, j, k, l;
            List<Point> Convex_hull = new List<Point>();
            for(i=0;i<list_of_point.Count;i++)
                for(j=i+1;j<list_of_point.Count;j++)
                    for(k=j+1;k<list_of_point.Count;k++)
                        for (l = k + 1; k < list_of_point.Count; k++)
                        {
                            if (IsV(list_of_point[i], list_of_point[j], list_of_point[k], list_of_point[l]))
                            {
                                Convex_hull.Add(list_of_point[i]);
                                Convex_hull.Add(list_of_point[j]);
                                Convex_hull.Add(list_of_point[k]);
                                Convex_hull.Add(list_of_point[l]);
                            }
                        }
            //=================================================

            output_file.writePoint(list_of_point);
            //
            Console.Read();
        }
        public static double V(Point a1, Point a2, Point a3)
        {
            double V = (a1.x * (a2.y * a3.z - a2.z * a3.y)- a1.y * (a2.x * a3.z - a2.z * a3.x) + a1.z * (a2.x * a3.y - a2.y * a3.x)) / 6.0f;
            return V;
        }
        public static Point Normal(Point a, Point b, Point c)
        {
            Point vector = new Point();
            vector.x = (b.y - b.x) * (c.z - c.x) - (c.y - c.x) * (b.z - b.x);
            vector.y = (a.y - a.x) * (c.z - c.x) - (c.y - c.x) * (a.z - a.x);
            vector.z = (a.y - a.x) * (b.z - b.x) - (b.y - b.x) * (a.z - a.x);
            return vector;
        }
        public static bool IsV ( Point a1, Point a2, Point a3, Point a4)
        {
            if( V(a1, a2, a3)!=0f && V(a1,a2,a4)!=0 && V (a3, a2, a4)!=0 && V(a1,a3,a4)!=0)
                return true;
                else 
                return false;
        }
        public static Verge createVerge(Point a,Point b,Point c, Point x)
        {
            Point vector = Normal(a, b, c);
            Verge v = new Verge();
            if (isHighter(vector,a,x))
            {
                v.a = a;
                v.b = b;
                v.c = c;
                v.norm = vector;
                return v;
            }
            else
            {
                v.a = a;
                v.b = b;
                v.c = c;
                vector.x = -vector.x;
                vector.y = -vector.y;
                vector.z = -vector.z;
                v.norm = vector;
                return v;
            }
        }
        public static double distance(Point a1, Point a2, Point a3, Point last_p)
        {
            //Визначники:
            double V_1 = (a2.y-a1.y)*(a3.z-a1.z)-(a2.z-a1.z)*(a3.y-a1.y);
            double V_2 = -(a2.x-a1.x)*(a3.z-a1.z)-(a2.z-a1.z)*(a3.x-a1.x);
            double V_3 = (a2.x-a1.x)*(a3.y-a1.y)-(a2.y-a1.y)*(a3.x-a1.x);
            //Вільний член в р-ні площини:
            double D = -a1.x*V_1 + a1.y*V_2 -a1.z*V_3;
            //Відстань:
            double result = Math.Abs(V_1 * last_p.x + V_2 * last_p.y + V_3 * last_p.z + D) / Math.Sqrt(Math.Pow(V_1, 2) + Math.Pow(V_2, 2) + Math.Pow(V_3, 2));
            return result;
        }
        public static bool isHighter(Point norm,Point beginer,Point point)
        {
            Point vec1=new Point();
            vec1.x = point.x - beginer.x;
            vec1.y = point.y - beginer.y;
            vec1.z = point.z - beginer.z;
            return ((norm.x * vec1.x + norm.y * vec1.y + norm.z * vec1.z) / 
                (Math.Sqrt(vec1.x * vec1.x + vec1.y * vec1.y + vec1.z * vec1.z) * Math.Sqrt(norm.x * norm.x + norm.y * norm.y + norm.z * norm.z)) < 0);
        }
        
    }
}
