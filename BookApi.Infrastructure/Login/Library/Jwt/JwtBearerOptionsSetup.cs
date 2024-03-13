namespace BookApi.Infrastructure.Login.Library.Jwt;

internal class JwtBearerOptionsSetup(IConfiguration manager) : IConfigureOptions<JwtBearerOptions>
{
    private const string SectionName = nameof(JwtBearerOptions);

    private readonly IConfiguration _configuration = manager;

    public void Configure(JwtBearerOptions options) => _configuration.GetRequiredSection(SectionName)?.Bind(options);
}
