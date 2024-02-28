using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BookApi.Presentation.Models.Common.Extensions;

internal static class RouteHandlerBuilderExtensions
{
    public static void ConfigureDocumentation<TType>(this RouteHandlerBuilder endpoint, ushort[] codes,
        string defaultContentType = "application/problem+json")
    {
        foreach (var code in codes.AsSpan())
        {
            endpoint.Produces<TType>(code, defaultContentType);
        }
    }
}
