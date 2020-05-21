using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileNameScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = "";
                string extension1 = "";
                string extension2 = "";

                #region 檢查並處理Input
                if (args.Length != 5)
                {
                    Console.WriteLine("Input Type Error");
                    Console.WriteLine("Program Return...");
                    return;
                }

                switch (args[0])
                {
                    case "-path":
                        if (args[2] != "-name")
                        {
                            Console.WriteLine("Input Type Error");
                            Console.WriteLine("Program Return...");
                            return;
                        }
                        path = args[1];
                        extension1 = args[3];
                        extension2 = args[4];
                        break;
                    case "-name":
                        if (args[3] != "-path")
                        {
                            Console.WriteLine("Input Type Error");
                            Console.WriteLine("Program Return...");
                            return;
                        }
                        path = args[4];
                        extension1 = args[1];
                        extension2 = args[2];
                        break;
                    default:
                        Console.WriteLine("Input Type Error");
                        Console.WriteLine("Program Return...");
                        return;
                }

                if (path == String.Empty || extension1 == String.Empty || extension2 == String.Empty || !Directory.Exists(path))
                {
                    Console.WriteLine("Path Error");
                    Console.WriteLine("Program Return...");
                    return;
                }
                #endregion

                Console.WriteLine($"Scanning In {path}...");

                List<string> imgName = Scanner.GetFileNameByFilenameExtension(path, extension1);
                List<string> xmlName = Scanner.GetFileNameByFilenameExtension(path, extension2);

                var extraImg = imgName.Except(xmlName).ToList();
                var extraXml = xmlName.Except(imgName).ToList();

                if (extraXml.Count == 0 && extraImg.Count == 0)
                {
                    Console.WriteLine("No Search any Redundant File...");
                    Console.WriteLine($"Total File Count : [{imgName.Count},{xmlName.Count}]");
                    Console.WriteLine("Program Return...");
                    return;
                }

                Console.WriteLine("Redundant File Name:");
                extraImg.ForEach(c => Console.Write(c + $".{extension1} "));
                extraXml.ForEach(c => Console.Write(c + $".{extension2} "));
                Console.Write("\nDelete Redundant File? (y/n)  ");
                var key = Console.ReadKey().KeyChar;

                string k = key.ToString();

                if (k == "y")
                {
                    Console.WriteLine("\nDelete Redundant File ....");

                    foreach (string s in extraImg)
                    {
                        System.IO.File.Delete(@$"{s}.{extension1}");
                    }

                    foreach (string s in extraXml)
                    {
                        System.IO.File.Delete(@$"{s}.{extension2}");
                    }

                    Console.Write("Delete Finish ....");
                }

                Console.WriteLine("\nProgram Return...");
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
