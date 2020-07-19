using FileUploader.Application.Interfaces;

namespace FileUploader.Application.Factories
{
    public interface ITransactionFileParserFactory
    {
        ITransactionFileParser CreateFileParser(string fileName);
    }
}