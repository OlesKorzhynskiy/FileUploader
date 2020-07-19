using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using FileUploader.Application.Exceptions;
using FileUploader.Application.Interfaces;
using FileUploader.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FileUploader.Application.Services
{
    public class XmlTransactionFileParser : ITransactionFileParser
    {
        public IEnumerable<Transaction> Parse(IFormFile xmlFile)
        {
            var doc = new XmlDocument();
            doc.Load(xmlFile.OpenReadStream());

            var transactionNodes = doc.DocumentElement?.SelectNodes("/Transactions/Transaction");
            if (transactionNodes == null)
            {
                throw new BadRequestException("File is empty");
            }

            var result = new List<Transaction>();
            foreach (XmlNode node in transactionNodes)
            {
                var dateText = GetNodeText(node, "TransactionDate");
                var amountText = GetNodeText(node, "PaymentDetails/Amount");
                var transaction = new Transaction()
                {
                    Id = GetNodeAttribute(node, "id"),
                    CurrencyCode = GetNodeText(node, "PaymentDetails/CurrencyCode"),
                    Amount = decimal.Parse(amountText, CultureInfo.InvariantCulture),
                    Date = DateTime.Parse(dateText),
                    Status = GetNodeText(node, "Status")
                };
                result.Add(transaction);
            }

            return result;
        }

        private static string GetNodeAttribute(XmlNode node, string name)
        {
            var attribute = node.Attributes?[name];
            if (attribute == null)
            {
                throw new BadRequestException($"{name} attribute doesn't exist in node");
            }

            return attribute.InnerText;
        }

        private static string GetNodeText(XmlNode node, string path)
        {
            var result = node.SelectSingleNode(path);
            if (result == null)
            {
                throw new BadRequestException($"{path} node doesn't exist in document");
            }

            return result.InnerText;
        }
    }
}