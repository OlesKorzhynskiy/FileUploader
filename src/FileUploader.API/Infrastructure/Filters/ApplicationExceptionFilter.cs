using System.Net;
using FileUploader.Application.Exceptions;
using FileUploader.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FileUploader.API.Infrastructure.Filters
{
    public class ApplicationExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ApplicationExceptionFilter> _logger;

        public ApplicationExceptionFilter(ILogger<ApplicationExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext exceptionContext)
        {
            var exception = exceptionContext.Exception;
            var httpContext = exceptionContext.HttpContext;

            _logger.LogError(exception, "Application threw exception: ");

            var response = new ErrorResponseModel { Message = exception.Message };
            var code = HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case BadRequestException badRequestException:
                    code = HttpStatusCode.BadRequest;
                    response.Errors = badRequestException.Errors;
                    break;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)code;
            exceptionContext.Result = new JsonResult(response);
        }
    }
}