namespace LoggingLibrary.Files.Entities
{
    using System.IO;
    using System.Linq;

    using Common;
    using Contracts;
    using Errors.Contracts;
    using Layouts.Contracts;
    using IOManagement.Contracts;
    using IOManagement.Entities;

    public class LogFile : IFile
    {
        private const string CurrentDirectory = "\\logs\\";
        private const string CurrentFile = "log.txt";

        private string currentPath;
        private IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(CurrentDirectory, CurrentFile);
            this.currentPath = this.IOManager.GetCurrentPath();
            this.IOManager.EnsureDirectoryAndFileExists();
            this.Path = System.IO.Path.Combine(this.currentPath + CurrentDirectory + CurrentFile);
        }

        public string Path { get; private set; }

        public ulong Size => GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            string formattedMessage = MessageParameters.GetFormattedMessage(layout, error);

            return formattedMessage;
        }
        
        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            ulong size = (ulong) text
                                    .Where(char.IsLetter)
                                    .Sum(c => c);

            return size;
        }

    }
}