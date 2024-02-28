using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace BookApi.Presentation.Models;

public static class Login
{
    public static WebApplication AddLogin(this WebApplication app)
    {
        app.MapGet("Login/Queries/{name}/{email}/{password}/{secret}", async Task<Ok<string?>>
            (ISender sender, CancellationToken token, string name, string email, string password, string secret = "NA") =>
        {
            var res = await sender.Send(new BookApi.Application.Login.Queries.Login(name, email, password, secret), token);
            return TypedResults.Ok<string?>(res.Entity);
        }).WithTags("Login");
        return app;
    }
}
