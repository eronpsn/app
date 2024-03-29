using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Eclilar.Aplicacao.Utils;

namespace Eclilar.Aplicacao.Middlewares
{
    public class ExcpetionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ExcpetionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExcpetionMiddleware>();
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomException ex)
            {
                await TratarErro(((int)ex.StatusCode), ex.Message, httpContext);
            }
            catch (Exception ex)
            {
                if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
                {
                    _logger.LogError(ex.Message);
                    await TratarErro(500, 
                                    JsonSerializer.Serialize(new { erro = ex.Message, innerException = ex.InnerException?.Message }),
                                    httpContext);
                }
                else 
                {
                    await TratarErro(500, JsonSerializer.Serialize(new { erro = "Erro inesperado" }), httpContext);
                }
            }
        }

        private async Task TratarErro(int statusCode, string message, HttpContext context)
        {
            var bytes = Encoding.UTF8.GetBytes(message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
