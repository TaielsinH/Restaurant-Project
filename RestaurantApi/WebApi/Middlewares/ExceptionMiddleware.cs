using System.Net;
using Application.Exceptions;

namespace WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message;

            switch (ex)
            {
                case ConflictException:
                    message = ex.Message;
                    status = HttpStatusCode.Conflict;
                    break;
                case BusinessRuleException:
                    message = ex.Message;
                    status = HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException:
                    message = ex.Message;
                    status = HttpStatusCode.NotFound;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = ex.Message;
                    break;
            }
            var errorPayload = new { message };
            var result = System.Text.Json.JsonSerializer.Serialize(errorPayload);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(result);  
        }
    }
}