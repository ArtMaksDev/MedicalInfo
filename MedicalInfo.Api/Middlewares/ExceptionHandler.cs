using MedicalInfo.App.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace MedicalInfo.Api.Middlewares
{
    public class ExceptionsHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionsHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbUpdateException ex)
            {
                SetClientResponse(context);

                await context.Response.WriteAsync(ex.InnerException!.Message);
            }
            catch (ClientException ex)
            {
                SetClientResponse(context);

                await context.Response.WriteAsync(ex.Message);

            }
        }

        public void SetClientResponse(HttpContext context)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "text/plain";

        }
    }

    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseExceptionsHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionsHandler>();
        }
    }
}
