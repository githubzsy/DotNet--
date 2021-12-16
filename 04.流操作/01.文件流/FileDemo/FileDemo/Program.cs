using System;
using System.IO;

namespace FileDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = File.ReadAllText("d:\\webapi_port_8001.txt");
            File.WriteAllText("d:\\webapi_port_8001.txt", "abcde");

            FileInfo fileInfo = new FileInfo("d:\\webapi_port_8001.txt");
            
            Console.WriteLine(str);
        }
    }
}
