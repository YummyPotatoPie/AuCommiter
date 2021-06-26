using System.IO;

namespace AuCommiter
{
    internal class Options
    {
        private int WorkTime = 3600;
        private int CommitTime = 600;
        private string CommitDirectory = Directory.GetCurrentDirectory();
        private string CommitBranch = "master";
        private string DefaultMessage = "Auto commit by AuCommiter: ";

        public Options SetWorkTime(int workTime)
        {
            WorkTime = workTime;
            return this;
        }

        public Options SetCommitTime(int commitTime)
        {
            CommitTime = commitTime;
            return this;
        }

        public Options SetCommitDirectory(string commitDirectory)
        {
            CommitDirectory = commitDirectory;
            return this;
        }

        public Options SetCommitBranch(string commitBranch)
        {
            CommitBranch = commitBranch;
            return this;
        }
    }
}
