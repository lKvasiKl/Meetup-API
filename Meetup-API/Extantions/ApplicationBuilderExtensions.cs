using Meetup_API.Middleware;

namespace Meetup_API.Extantions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UserErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
