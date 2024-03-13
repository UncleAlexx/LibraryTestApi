var builder = WebApplication.CreateBuilder(args);
builder.AddWebApi().AddInfrastructure().AddApplication().AddPresentation();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
app.UseAuthentication().UseAuthorization();
app.MapEndpoints().UseSwagger().UseSwaggerUI();
app.Run();