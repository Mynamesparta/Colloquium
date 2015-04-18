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
            float a = new float();
            using (StreamReader sw = file.OpenText())
            {
                int.TryParse(sw.ReadLine(), out lenght);
                Console.WriteLine("Lenght:" + lenght);
                text = sw.ReadLine();
                while (text!=""&&text!=" ")
                {
                    Console.WriteLine(text);
                    if (sw.EndOfStream)
                        break;
                    number = text.Split(' ');
                    point = new Point();
                    float.TryParse(number[0], out a);
                    point.x = float.Parse(number[0].ToString());
                    point.x = a;
                    float.TryParse(number[1], out a);
                    point.y = a;
                    float.TryParse(number[2], out a);
                    point.z = a;
                    list.Add(point);
                    text = sw.ReadLine();
                    Console.WriteLine("point:"+point.x + " " + point.y + " " + point.z);
                }
            }
            //return list;
        }
    }
}
