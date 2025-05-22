namespace FileConverter.Core.Interfaces
{
    public interface IFileConverter
    {
        string InputFormat { get; }
        string OutputFormat { get; }

        string Convert(string inputContent);
    }
}
