using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploader.Application.Interfaces;
using FileUploader.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileUploader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync([FromForm] UploadFileRequestModel model)
        {
            await _transactionService.AddAsync(model.File);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionResponseModel>>> GetAsync([FromQuery] TransactionFilterModel filterModel)
        {
            var result = await _transactionService.GetAsync(filterModel);
            return Ok(result);
        }
    }
}