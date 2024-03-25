namespace Library.Presentation.Endpoints;

internal static class Login
{
    internal static WebApplication MapLogin(this WebApplication app)
    {
        var queries = app.ConfigureGroups(SecondaryGroups.LoginJwt);
        queries.MapGet("{name}-{email}-{password}-{secret}", async Task<Ok<string?>>
            (ISender sender, CancellationToken token, string name, string email, string password, string secret = "NA") =>
        {
            var result = await sender.Send(new LoginQuery(name, email, password, secret), token);
            return TypedResults.Ok<string?>(result.Entity);
        });
        return app;
    }
}
