using System;
using System.IO;

namespace AuCommitter
{
    internal static class Utilites
    {
        public static int ParseTime(string time)
        {
            int resultTime = 0;
            int mult = 1;
            for (int i = 0; i < time.Length; i++)
            {
                if (char.IsDigit(time[i]))
                {
                    string number = "";
                    while (char.IsDigit(time[i]))
                    {
                        number += time[i];
                        i++;
                    }
                    if (!int.TryParse(number, out mult))
                    {
                        throw new Exception("Invalid option arg");
                    }
                }
                if (char.IsLetter(time[i]))
                {
                    switch (time[i])
                    {
                        case 'h':
                            resultTime += mult * 3600;
                            mult = 1;
                            break;
                        case 'm':
                            resultTime += mult * 60;
                            mult = 1;
                            break;
                        case 's':
                            resultTime += mult;
                            mult = 1;
                            break;
                        default:
                            throw new Exception("Invalid option arg");
                    }
                }
            }
            return resultTime;
        }

        public static bool IsRepository(string path) => Directory.Exists(path) && Directory.Exists(path + "\\.git");

        public static bool IsGit(string path) => Directory.Exists(path) && File.Exists(path + "\\git.exe");
    }
}
