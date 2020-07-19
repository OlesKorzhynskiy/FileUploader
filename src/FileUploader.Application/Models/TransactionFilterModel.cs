using System;

namespace FileUploader.Application.Models
{
    public class TransactionFilterModel
    {
        public string Currency { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string Status { get; set; }
    }
}