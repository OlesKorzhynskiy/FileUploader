using System;
using FileUploader.Application.Helpers;
using FileUploader.Application.Interfaces;
using FileUploader.Application.Services;

namespace FileUploader.Application.Factories
{
    public class TransactionFileParserFactory : ITransactionFileParserFactory
    {
        public ITransactionFileParser CreateFileParser(string fileName)
        {
            if (fileName.EndsWith(Constants.CsvExtension))
            {
                return new CsvTransactionFileParser();
            }

            if (fileName.EndsWith(Constants.XmlExtension))
            {
                return new XmlTransactionFileParser();
            }

            throw new Exception("Unknown format");
        }
    }
}