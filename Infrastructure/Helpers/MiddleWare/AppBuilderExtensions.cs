
using Microsoft.AspNetCore.Builder;
using System.Runtime.CompilerServices;

namespace Infrastructure.Helpers.MiddleWare;

public static class AppBuilderExtensions
{
    public static IApplicationBuilder UseUserSessionValidation(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<UserSessionValidationMiddleWare>();
    }
}
