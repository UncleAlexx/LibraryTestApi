namespace Library.Presentation;

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
