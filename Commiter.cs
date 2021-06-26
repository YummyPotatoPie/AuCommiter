using System;
using System.Collections.Generic;
using System.Text;

namespace AuCommiter
{
    class Commiter
    {
        static void Main(string[] args)
        {
            StringBuilder options = new();
            foreach (string arg in args)
            {
                options.Append(arg);
            }

            Dictionary<string, string> parsedOptions = new();
            try
            {
                parsedOptions = ArgsParser.Parse(options.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (string key in parsedOptions.Keys)
            {
                switch (key)
                {
                    case "wt":
                        break;
                    case "ct":
                        break;
                    case "d":
                        break;
                    case "b":
                        break;
                    case "m":
                        break;
                    default:
                        break;
                }
            }

        }

        static void Execute(Options options)
        {

        }
    }
}
