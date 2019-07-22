namespace LoggingLibrary.IOManagement.Entities
{
    using System.IO;

    using Contracts;

    public class IOManager : IIOManager
    {
        private string currentPath;
        private string currentDirectory;
        private string currentFile;

        public IOManager()
        {
            this.currentPath = this.GetCurrentPath();
        }

        public IOManager(string currentDirectoryPath, string currentFilePath)
            :this()
        {
            this.currentDirectory = currentDirectoryPath;
            this.currentFile = currentFilePath;
        }

        public string CurrentDirectoryPath => Path.Combine(this.currentPath + this.currentDirectory);

        public string CurrentFilePath => Path.Combine(this.CurrentDirectoryPath + this.currentFile);

        public void EnsureDirectoryAndFileExists()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}