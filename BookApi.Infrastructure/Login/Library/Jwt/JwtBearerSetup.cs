namespace Library.Infrastructure.Login.Library.Jwt;

public class JwtBearerOptionsSetup(IConfiguration config) : IConfigureOptions<JwtBearerOptions>
{
    private const string SectionName = "JwtOptions";
    private readonly IConfiguration _configuration = config;

    public void Configure(JwtBearerOptions options) => _configuration.GetSection(SectionName);
}
