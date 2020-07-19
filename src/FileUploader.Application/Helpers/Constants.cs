using System.Collections.Generic;

namespace FileUploader.Application.Helpers
{
    public class Constants
    {
        public static string[] AllowedFileExtensions = { CsvExtension, XmlExtension };
        public const int MaxFileSize = 1000000;
        public const string CsvExtension = ".csv";
        public const string XmlExtension = ".xml";
    }
}