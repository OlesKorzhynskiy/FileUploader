using System;

namespace FileUploader.Domain.Entities
{
    public class Transaction
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyCode { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }
    }
}