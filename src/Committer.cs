using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace AuCommitter
{
    class Committer
    {
        static void Main(string[] args)
        {
            StringBuilder cmdOptions = new();
            foreach (string arg in args)
            {
                cmdOptions.Append(arg);
            }

            Dictionary<string, string> parsedOptions = new();
            try
            {
                parsedOptions = ArgsParser.Parse(cmdOptions.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Options options = new();
            foreach (string key in parsedOptions.Keys)
            {
                switch (key)
                {
                    case "wt":
                        options.WorkTime = Utilites.ParseTime(parsedOptions[key]);
                        break;
                    case "ct":
                        options.CommitTime = Utilites.ParseTime(parsedOptions[key]);
                        break;
                    case "gd":
                        if (Utilites.IsGit(parsedOptions[key]))
                        {
                            options.CommitDirectory = parsedOptions[key];
                        }
                        else
                        {
                            Console.WriteLine("Directory is not Git folder");
                            return;
                        }
                        break;
                    case "d":
                        if (Utilites.IsRepository(parsedOptions[key]))
                        {
                            options.CommitDirectory = parsedOptions[key];
                        }
                        else
                        {
                            Console.WriteLine("Directory is not repository");
                            return;
                        }
                        break;
                    case "b":
                        options.CommitBranch = parsedOptions[key];
                        break;
                    case "m":
                        options.DefaultMessage = parsedOptions[key];
                        break;
                    default:
                        Console.WriteLine("Invalid option: " + key);
                        return;
                }
            }

            Execute(options);
        }

        static void Execute(Options options)
        {
            int timeCounter = 1;
            int commitCount = 1;
            Console.WriteLine("AuCommiter had been started");
            while (timeCounter <= options.WorkTime)
            {
                if (timeCounter % options.CommitTime == 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Process process = new();
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.FileName = options.GitDirectory + "\\git.exe";
                        process.StartInfo.Arguments = $"-C \"{options.CommitDirectory}\" add .";
                        process.Start();

                        process.StartInfo.Arguments = $"-C \"{options.CommitDirectory}\" commit -m \"{options.DefaultMessage + ((commitCount >> 14) ^ timeCounter)}\"";
                        process.Start();

                        Thread.Sleep(1000);
                        timeCounter++;
                    }
                    Console.WriteLine($"Commited changes: {commitCount}");
                    commitCount++;
                }
                Thread.Sleep(1000);
                timeCounter++;
            }
            Console.WriteLine("AuCommiter had been ended process");
        }
    }
}
