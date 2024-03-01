namespace Library.Infrastructure.Login.Library.Jwt;

internal record struct JwtTokenOptions(SigningCredentials SigningCredentials, string ValidIssuer, string ValidAudience, Claim[] Claims)
{
    public static DateTime Expiration => DateTime.Now.AddHours(1);
}
