var builder = WebApplication.CreateBuilder(args);
builder.AddWebApi().AddInfrastructure().AddApplication().AddPresentation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
var app = builder.Build();
app.MigrateDatabase();

app.MapEndpoints().UseSwagger().UseSwaggerUI();

app.Run();