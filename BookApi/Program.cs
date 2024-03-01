using Library.Infrastructure.Login.Library.Jwt;

var builder = WebApplication.CreateBuilder(args); 
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddSecurityScheme();
builder.Services.AddInfrastructure(builder.Configuration);
builder.AddApplication();

builder.Services.AddOptions<JwtBearerOptions>().BindConfiguration("JwtOptions").ValidateDataAnnotations();
builder.Services.AddAuth2(builder.Services.BuildServiceProvider().GetService<IOptions<JwtBearerOptions>>());
builder.Services.AddAuth();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPresentation2();
var app = builder.Build();
app.AddPresentation(builder.Services);
app.UseSwagger().UseSwaggerUI();
app.Run();
