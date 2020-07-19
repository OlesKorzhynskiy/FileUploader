using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.TypeConversion;
using FileUploader.Application.Interfaces;
using FileUploader.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FileUploader.Application.Services
{
    public class CsvTransactionFileParser : ITransactionFileParser
    {
        public IEnumerable<Transaction> Parse(IFormFile file)
        {
            var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var options = new TypeConverterOptions
            {   
                Formats = new [] { "dd/MM/yyyy hh:mm:ss" }
            };

            csv.Configuration.TypeConverterOptionsCache.AddOptions<DateTime>(options);
            csv.Configuration.HasHeaderRecord = false;

            var records = csv.GetRecords<Transaction>();

            return records.ToList();
        }
    }
}