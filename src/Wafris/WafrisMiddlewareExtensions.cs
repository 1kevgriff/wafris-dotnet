
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Wafris;

public static class WafrisMiddlewareExtensions
{
    public static IApplicationBuilder UseWafris(
        this IApplicationBuilder builder, WafrisOptions options)
    {
        // validate options with DataAnnotations
        Validator.ValidateObject(options, new ValidationContext(options), true);

        var wafrisOptions = Options.Create(options);
        return builder.UseMiddleware<WafrisMiddleware>(wafrisOptions);
    }

    public static IServiceCollection AddWafris(
        this IServiceCollection services)
    {
        services.AddSingleton<WafrisMiddleware>();
        return services;
    }
}