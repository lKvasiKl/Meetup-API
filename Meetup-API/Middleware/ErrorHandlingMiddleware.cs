using Business.Exceptions;
using System.Net;
using System.Text.Json;

namespace Meetup_API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                switch (error)
                {
                    case BadRequestException _:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case NotAuthorizedException _:
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    case NotAuthenticatedException _:
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    case NotFoundException _:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                }

                await context.Response.WriteAsync(JsonSerializer.Serialize(error.Message));
            }
        }
    }
}
