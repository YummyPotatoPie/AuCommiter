using System;
using System.Collections.Generic;
using System.Text;

namespace AuCommiter
{
    class Commiter
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

        }

        static void Execute(Options options)
        {
            int timeCounter = 0;
            while (timeCounter <= options.WorkTime)
            {

            }
        }
    }
}
