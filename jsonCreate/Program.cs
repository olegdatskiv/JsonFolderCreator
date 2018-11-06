using System;
using System.IO;

namespace jsonCreate
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please, enter path for folder. Example : E:\\Test");
                string path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    Task.CreateJson(path);
                    Console.WriteLine("Json file successfully created");
                }
                else
                {
                    throw new ArgumentException($"Path '{path}' is not set correct");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
