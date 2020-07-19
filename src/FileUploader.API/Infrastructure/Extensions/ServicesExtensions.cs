using System;
using System.Collections.Generic;
using FileUploader.Application.Factories;
using FileUploader.Application.Interfaces;
using FileUploader.Application.Services;
using FileUploader.Domain;
using FileUploader.Domain.Repositories;
using FileUploader.Infrastructure;
using FileUploader.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileUploader.API.Infrastructure.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection WithServices(this IServiceCollection services)
        {
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITransactionFileParserFactory, TransactionFileParserFactory>();

            return services;
        }
    }
}