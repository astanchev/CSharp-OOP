namespace LoggingLibrary.IOManagement.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        void EnsureDirectoryAndFileExists();

        string GetCurrentPath();
    }
}