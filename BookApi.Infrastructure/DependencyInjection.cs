using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using BookApi.Infrastructure.Common;
using BookApi.Infrastructure.Authentication.Library.Jwt;
using BookApi.Infrastructure.Book.Persistence.Enums;
using BookApi.Infrastructure.Book.Persistence.Library;
using BookApi.Infrastructure.Book.Persistence.Repositories;
using BookApi.Infrastructure.Book.Persistence.Constants.Common;
using Microsoft.EntityFrameworkCore;

namespace Autoservice.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddSingleton<JwtTokenFactory>();
        InitilizeConnectionString(configuration);
        configuration.AddUserSecrets<BookRepository>();
        return services.AddUnitsOfWork().AddRepositories().AddDbContexts().AddKeyedSqlConnections();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) =>  services.AddScoped<IBookRepository, BookRepository>();

    public static IServiceCollection AddDbContexts(this IServiceCollection services)
        => services.AddSqlServer<LibraryContext>(SqlParameters.LibraryConnectionString);

    //private static IServiceCollection AddMappers(this IServiceCollection services) => services.AddSingleton<EntitiesMapper>();

    private static IServiceCollection  AddUnitsOfWork(this IServiceCollection services) => services.AddScoped<IUnitOfWork, LibraryUnitOfWork>();

    private static IServiceCollection AddKeyedSqlConnections(this IServiceCollection services) => 
        services.AddKeyedScoped(Databases.Library, (x,y) => new SqlConnection(SqlParameters.LibraryConnectionString));
   
    private static void InitilizeConnectionString(IConfigurationManager configuration) => ConfigDecorator.InitializeConfig(configuration);
}