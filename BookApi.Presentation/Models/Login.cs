namespace Library.Presentation.Models;

internal static class Login
{
    internal static WebApplication MapLogin(this WebApplication app)
    {
        var (_, queries) = app.ConfigureOpenApi(PrimaryGroups.LoginMainGroup);
        queries.MapGet("Login/Queries/{name}/{email}/{password}/{secret}", async Task<Ok<string>>
            (ISender sender, CancellationToken token, string name, string email, string password, string secret = "NA") =>
        {
            var result = await sender.Send(new LoginQuery(name, email, password, secret), token);
            return TypedResults.Ok(result.Entity);
        });
        return app;
    }
}
