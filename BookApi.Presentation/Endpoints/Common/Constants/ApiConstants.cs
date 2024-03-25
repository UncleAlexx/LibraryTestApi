namespace Library.Presentation.Endpoints.Common.Constants;

internal static class ApiConstants
{
    public const string BookSecondaryGroup = "books";
    public const string LoginJwtSecondaryGroup = "login-tokens";
    public const string DefaultSecondaryGroup = "default";
    public const string RouteGroup = $"{ApiName}/{ApiVersion}";
    private const string ApiVersion = "v1";
    private const string ApiName = "library-api";
}