using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GroupChatApplication.Api.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var message = exception.Message;
            var customMessage = exception.Message;

            switch (exception)
            {
                case AppException e:
                    // custom application error
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    // not found error
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // unhandled error
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    message = "Something Went Wrong, Please Try Again Later";
                    break;
            }

            var result = JsonSerializer.Serialize(new { StatusCode = context.Response.StatusCode, Message = message, CustomMessage = customMessage });
            await context.Response.WriteAsync(result);
        }
    }
}
