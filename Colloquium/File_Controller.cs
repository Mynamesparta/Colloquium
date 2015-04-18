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
            file = new FileInfo(System.IO.Directory.GetCurrentDirectory() + name);
            Console.WriteLine(file.FullName);
            if (file.Exists)
            {
                file.Delete();
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
            using (StreamReader sw = file.OpenText())
            {
                text=sw.ReadToEnd();
            }
            return text;
        }
    }
}
