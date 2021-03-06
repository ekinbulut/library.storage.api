using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library.Storage.Api.Filters
{
    [ExcludeFromCodeCoverage]
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            HttpStatusCode httpStatusCode;

            var message = context.Exception.Message;

            if (exception is ValidationException)
            {
                httpStatusCode = HttpStatusCode.BadRequest;
            }
            else if (exception is InvalidOperationException)
            {
                httpStatusCode = HttpStatusCode.BadRequest;
            }
            else if (exception is TimeoutException)
            {
                httpStatusCode = HttpStatusCode.BadGateway;
            }
            else
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
                message = "Unexpected Error Occurs";
            }

            context.Result = new ObjectResult(message) {StatusCode = (int) httpStatusCode};

            base.OnException(context);
        }
    }
}