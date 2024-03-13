namespace Library;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddWebApi(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JsonOptions>(options =>
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder.AddSwaggerOptions();
        return builder;
    }

    private static WebApplicationBuilder AddSwaggerOptions(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(swaggerOptions =>
        {
            swaggerOptions.AddSecurityDefinition("Bearer", new()
            {
                In = ParameterLocation.Header,
                Description = "Please provide a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            swaggerOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        }
                    }, []
                }
            });
        });
        return builder;
    }
}
