using System.IO;

namespace AuCommitter
{
    internal class Options
    {
        public int WorkTime { get; set; } = 3600;
        public int CommitTime { get; set; } = 600;
        public string CommitDirectory { get; set; } = Directory.GetCurrentDirectory();
        public string CommitBranch { get; set; }  = "master";
        public string DefaultMessage { get; set; } = "Auto commit by AuCommiter: ";
        public string GitDirectory { get; set; } = "C:\\Program Files\\Git\\cmd";
    }
}
