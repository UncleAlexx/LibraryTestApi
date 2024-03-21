namespace Library.Presentation.Endpoints.Common.Extensions;    

internal static class DocumentationExtensions
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
