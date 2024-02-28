using BookApi.Infrastructure.Authentication.Library.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BookApi.Infrastructure.Authentication.Library;

public class JwtBearerOptionsSetup(IConfiguration config) : IConfigureOptions<JwtBearerOptions>
{
    private const string SectionName = "JwtOptions";
    private readonly IConfiguration _configuration = config;

    public void Configure(JwtBearerOptions options) => _configuration.GetSection(SectionName);
}
