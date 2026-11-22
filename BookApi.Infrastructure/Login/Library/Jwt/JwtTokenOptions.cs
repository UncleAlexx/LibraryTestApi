namespace Library.Infrastructure.Login.Library.Jwt;

internal record struct JwtTokenOptions(in SigningCredentials SigningCredentials, in string ValidIssuer, 
    in string ValidAudience, in Claim[] Claims)
{
    public static DateTime Expiration => DateTime.Now.AddHours(1);
}
