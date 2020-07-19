using System.Collections.Generic;

namespace FileUploader.Application.Helpers
{
    public class Constants
    {
        public static string[] AllowedFileExtensions = { CsvExtension, XmlExtension };
        public const int MaxFileSize = 1000000;
        public const string CsvExtension = ".csv";
        public const string XmlExtension = ".xml";
        public static Dictionary<string, string> StatusMap = new Dictionary<string, string>()
        {
            { "Approved", "A" },
            { "Failed", "R" },
            { "Rejected", "R" },
            { "Finished", "D" },
            { "Done", "D" }
        };
    }
}