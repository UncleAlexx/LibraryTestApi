var builder = WebApplication.CreateBuilder(args);
builder.AddInfrastructure().AddApplication().AddPresentation().AddWebApi();
var app = builder.Build();
app.MigrateDatabase();
app.MapEndpoints().UseSwagger().UseSwaggerUI();
app.Run();