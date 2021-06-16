using Desafio.Easynvest.WebApi.Filters;
using Microsoft.AspNetCore.Builder;

namespace Desafio.Easynvest.WebApi.Extensions
{
    public static class HandleExceptionsMiddlewareExtensions
    {
        public static IApplicationBuilder UseTratarExcecoes(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandleExceptionsMiddleware>();
        }
    }
}
