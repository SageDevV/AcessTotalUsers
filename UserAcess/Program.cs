using System;
using System.IO;
using UserAcess.Entities;
using System.Collections.Generic;

namespace UserAcess
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<LogRecord> set = new HashSet<LogRecord>();
            
            Console.WriteLine("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(' ');
                        string name = line[0];
                        DateTime instant = DateTime.Parse(line[1]);
                        set.Add(new LogRecord { Username = name, Instant = instant });
                        Console.WriteLine(line);
                    }

                    Console.WriteLine("Total Users: " + set.Count);
                }

            }

            catch (IOException e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
