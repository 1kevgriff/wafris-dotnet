using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Wafris;

public class WafrisMiddleware
{
    private readonly RequestDelegate _next;
    private readonly WafrisOptions _options;
    private readonly ConnectionMultiplexer _redis;

    public WafrisMiddleware(RequestDelegate next, IOptions<WafrisOptions> options)
    {
        _next = next;
        _options = options.Value;
        _redis = ConnectionMultiplexer.Connect(_options.RedisConnectionString);

        /* additional configuration logic goes here */
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Middleware logic goes here
        

        /* allow connection */
        await _next(context);
    }
}