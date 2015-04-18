using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Colloquium
{
    public class File
    {
        string file_name;// = "result.txt";
        //string path=
        FileInfo file;

        public File(string name)
        {
            file_name = name;
            
            //
            file_name = System.IO.Directory.GetCurrentDirectory() +'\\'+ name;
            //file_name.Replace("Debug", "");
            file = new FileInfo(file_name);
            Console.WriteLine(file_name);
            if (file.Exists)
            {
                Console.WriteLine("nice");
            }
            else
            {
            }
        }
        public void Write(string text)
        {
            using (StreamWriter sw = file.AppendText())
            {
                sw.WriteLine(text);
            }
        }
        public string Read()
        {
            string text;
            Console.WriteLine(file.FullName);
            if (file.Exists)
            {
                Console.WriteLine("nice world");
            }
            StreamReader sw = file.OpenText();
            {
                text=sw.ReadToEnd();
            }
            return text;
        }
        public void readPoint(ref List<Point> list)
        {
            Point point;
            string[] number;
            string text;
            int lenght=new int();
            double a = new double();
            using (StreamReader sw = file.OpenText())
            {
                int.TryParse(sw.ReadLine(), out lenght);
                Console.WriteLine("Lenght:" + lenght);
                text = sw.ReadLine();
                while (text!=""&&text!=" ")
                {
                    text=text.Replace('.', ',');
                    if (sw.EndOfStream)
                        break;
                    number = text.Split(' ');
                    point = new Point();
                    double.TryParse(number[0], out a);
                    Console.WriteLine(a);
                    point.x = a;
                    double.TryParse(number[1], out a);
                    point.y = a;
                    double.TryParse(number[2], out a);
                    point.z = a;
                    list.Add(point);
                    text = sw.ReadLine();
                    Console.WriteLine("point:"+point.x + " " + point.y + " " + point.z);
                }
            }
            //return list;
        }
        public void writePoint(List<Point> list)
        {
            using (StreamWriter sw = file.AppendText())
            {
                sw.WriteLine(list.Count.ToString());
                foreach (Point point in list)
                {
                    sw.WriteLine(point.x.ToString() + " "+point.y.ToString()+" "+point.z.ToString()+" ");
                }
            }
        }
    }
}
