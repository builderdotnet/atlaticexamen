using AtlanticCity.BibliotecarioJC.Domain.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace AtlanticCity.BibliotecarioJC.Api.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    exception, "Error no controlado: {Message}", exception.Message);

                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(new Result<string>(new List<string> { "Error no controlado, comuniquese con el area de sistemas!" }));
            }
        }
    }
}