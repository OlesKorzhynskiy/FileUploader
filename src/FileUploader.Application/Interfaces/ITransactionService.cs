using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileUploader.Application.Interfaces
{
    public interface ITransactionService
    {
        Task AddAsync(IFormFile file);
    }
}