using System.Collections.Generic;

namespace AuCommiter
{
    class Commiter
    {
        static void Main(string[] args)
        {
            string argsString = "";
            foreach (string arg in args)
                argsString += arg;

            Dictionary<string, string> parsedArgs = ArgsParser.Parse(argsString);
        }
    }
}
