namespace Library.Infrastructure;

public  static class DependencyInjection
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        InitilizeConnectionString(builder.Configuration).AddUserSecrets<BookRepository>();
        builder.Services.ConfigureOptions<JwtBearerOptionsSetup>().AddOptionsWithValidateOnStart<JwtBearerOptions>().
            ValidateDataAnnotations().ValidateOnStart();
        using var scope = builder.Services.BuildServiceProvider();
            var options = scope.GetRequiredService<IOptions<JwtBearerOptions>>().Value;
            builder.Services.AddAuth(options).AddAuthorizationPolicies(options).AddUnitsOfWork().AddRepositories().AddDbContexts().
            AddKeyedSqlConnections().AddSingleton<JwtTokenFactory>();
        return builder;
    }
    private static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services, JwtBearerOptions options)
    {
        var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().
            RequireClaim(LibraryUserClaimType.Name).RequireClaim(LibraryUserClaimType.Email).
            RequireClaim(LibraryUserClaimType.Password);
        services.AddAuthorizationBuilder().SetDefaultPolicy(policy.Build()).AddPolicy("Admin",
                policy.RequireClaim(LibraryUserClaimType.Secret, options.IssuerSigningKey!).Build());
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, JwtBearerOptions options)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(bearerOptions =>
        bearerOptions.TokenValidationParameters = new()
        {
            ValidateIssuer = options.ValidateIssuer,
            ValidateAudience = options.ValidateAudience,
            ValidateLifetime = options.ValidateLifetime,
            ValidateIssuerSigningKey = options.ValidateIssuerSigningKey,
            ValidIssuer = options.ValidIssuer,
            ValidAudience = options.ValidAudience,
            RequireExpirationTime = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.IssuerSigningKey!))
        });
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) =>  
        services.AddScoped<IBookRepository, BookRepository>();

    public static IServiceCollection AddDbContexts(this IServiceCollection services)
        => services.AddSqlServer<LibraryContext>(SqlParameters.LibraryConnectionString);

    private static IServiceCollection  AddUnitsOfWork(this IServiceCollection services) => 
        services.AddScoped<IUnitOfWork, LibraryUnitOfWork>();

    private static IServiceCollection AddKeyedSqlConnections(this IServiceCollection services) => 
        services.AddKeyedScoped(Databases.Library, (_, _) => new SqlConnection(SqlParameters.LibraryConnectionString));
   
    private static IConfigurationManager InitilizeConnectionString(this IConfigurationManager configuration)
    {
        ConfigDecorator.InitializeConfig(configuration);
        return configuration;
    }
}