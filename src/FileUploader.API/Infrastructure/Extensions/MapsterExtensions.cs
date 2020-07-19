using System;
using FileUploader.Application.Helpers;
using FileUploader.Application.Models;
using FileUploader.Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace FileUploader.API.Infrastructure.Extensions
{
    public static class MapsterExtensions
    {
        public static IServiceCollection WithMapster(this IServiceCollection services)
        {
            TypeAdapterConfig<Transaction, TransactionResponseModel>
                .NewConfig()
                .Map(dest => dest.Payment, src => $"{src.Amount} {src.CurrencyCode}")
                .Map(dest => dest.Status, src => Constants.StatusMap[src.Status]);

            return services;
        }
    }
}