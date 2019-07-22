namespace LoggingLibrary.Files.Contracts
{
    using Errors.Contracts;
    using Layouts.Contracts;

    public interface IFile
    {
        string Path { get; }

        ulong Size { get; }

        string Write(ILayout layout, IError error);
    }
}