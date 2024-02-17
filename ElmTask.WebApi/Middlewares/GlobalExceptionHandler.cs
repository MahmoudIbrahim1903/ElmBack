using ElmTask.Application.Common.Dtos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ElmTask.WebApi.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IWebHostEnvironment environment)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                UseGlobalExceptionHandler(context, e, environment);
            }
        }

        public void UseGlobalExceptionHandler(HttpContext context, Exception ex, IWebHostEnvironment environment)
        {
            var response = context.Response;

            var result = new ExceptionResponse()
            {
                IsSuccess = false,
                Errors = new[] { "server-error" }
            };

            if (ex == null) return;
            switch (ex)
            {
                case Exception exception:
                    response.StatusCode = 500;
                    result.Errors = new[] { exception.Message };
                    break;
                default:
                    response.StatusCode = 500;
                    result.Errors = environment.IsProduction() == false ? new[] { ex.Message.ToString() }
                                                                        : null;
                    break;
            }
            response.WriteAsync(JsonConvert.SerializeObject(result));

        }
    }
}
