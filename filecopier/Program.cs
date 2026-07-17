using System;
using System.IO;

namespace FileCopier
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== File Uploader ===");
                Console.WriteLine("1. Local copy");
                Console.WriteLine("2. Cloud upload (Dropbox)");
                Console.WriteLine("3. Change token");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        new Copier().Run();
                        break;
                    case "2":
                        new Uploader().Run();
                        break;
                    case "3":
                        Console.Write("New Dropbox token: ");
                        string t = (Console.ReadLine() ?? "").Trim();
                        File.WriteAllText("token.txt", t);
                        Console.WriteLine("Token saved.");
                        break;
                    case "4":
                        return;
                }
            }
        }
    }
}
