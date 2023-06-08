using App.Helpers.Exceptions;

namespace App.Middlewares
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public Error(int statusCode, string message, string stackTrace)
        {
            StatusCode = statusCode;
            Message = message;
            StackTrace = stackTrace;
        }

    }

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (HttpException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                var error = new Error(ex.StatusCode, ex.Message, ex.StackTrace!);
                await context.Response.WriteAsJsonAsync(error);
            }
            catch (Exception ex)
            {
                var statusCode = 500;
                context.Response.StatusCode = statusCode;
                var error = new Error(statusCode, ex.Message, ex.StackTrace!);
                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
