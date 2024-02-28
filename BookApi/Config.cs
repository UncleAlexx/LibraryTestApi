namespace BookApi;

public static class Config
{
    static JwtBearerOptions Options { get; set; }
    public static void AddAuth2(this IServiceCollection collection, IOptions<BookApi.Infrastructure.Authentication.Library.Jwt.JwtBearerOptions> config) 
    { 
        Options = config.Value;
        collection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            x => x.TokenValidationParameters = new()
        {
            ValidateIssuer = Options.ValidateIssuer,
            ValidateAudience = Options.ValidateAudience,
            ValidateLifetime = Options.ValidateLifetime,
            ValidateIssuerSigningKey = Options.ValidateIssuerSigningKey,
            ValidIssuer = Options.ValidIssuer,
            ValidAudience = Options.ValidAudience,
            RequireExpirationTime = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Options.IssuerSigningKey))
        });
    }

    public static void AddAuth(this IServiceCollection se)
    {
        var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().
            RequireClaim(LibraryUserClaimType.Name).RequireClaim(LibraryUserClaimType.Email).
            RequireClaim(LibraryUserClaimType.Password);
        se.AddAuthorizationBuilder().SetDefaultPolicy(policy.Build()).AddPolicy("Admin", policy.RequireClaim(LibraryUserClaimType.Secret, Options.IssuerSigningKey).Build());
    }

    public static void AddSecurityScheme (this IServiceCollection services)
    {
        services.AddSwaggerGen(x =>
        {
            x.AddSecurityDefinition("Bearer", new()
            {
                In = ParameterLocation.Header,
                Description = "Please provide a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            x.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        }
                    }, new List<string>()
                }
            });
        });
    }
}
