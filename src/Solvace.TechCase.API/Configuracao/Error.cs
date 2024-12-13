using System.Net;

namespace Solvace.TechCase.API.Configuracao
{
    public class Erro
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Erro> _logger;

        public Erro(RequestDelegate next, ILogger<Erro> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.NotFound);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.NotImplemented);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.NotFound);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCodes)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCodes;

            var result = new { message = exception.Message };
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
