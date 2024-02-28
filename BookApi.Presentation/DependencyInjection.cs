using BookApi.Presentation.Contracts.Book.Common;
using BookApi.Presentation.Contracts.Book.Common.Mappers;
using BookApi.Presentation.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookApi.Presentation;

public static class DependencyInjection
{
    public static WebApplication AddPresentation(this WebApplication app, IServiceCollection services)
    {
        return app.AddBookCommands().AddLogin();
    }
    public static void AddPresentation2(this  IServiceCollection services)
    {
        services.AddSingleton<IBookMapper, BookMapper>();
    }
}
