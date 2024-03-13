using Library.Presentation.Models;

namespace Library.Presentation;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddPresentation(this WebApplicationBuilder builder) => builder.AddMappers();

    public static WebApplication MapEndpoints(this WebApplication app) => app.MapBook().MapLogin();

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IBookMapper, BookMapper>();
        return builder;
    }
}
