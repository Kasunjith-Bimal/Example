using ExceptionHandelingMiddleware.Model;
using System;
using System.Net;
using System.Text.Json;

namespace ExceptionHandelingMiddleware.Middleware
{
    public class GlobalExceptionHandelingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandelingMiddleware> _logger;

        public GlobalExceptionHandelingMiddleware(ILogger<GlobalExceptionHandelingMiddleware> logger)
        {
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                ErrorDetails errorDetails = new ErrorDetails
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server error",
                    Title = "Server error",
                    Details = "An internal server Error"
                };

                string json = JsonSerializer.Serialize(errorDetails);
                 
                await context.Response.WriteAsync(json);

              

            }
        }
    }
}
