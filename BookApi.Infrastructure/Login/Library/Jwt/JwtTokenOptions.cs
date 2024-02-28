
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Library.Infrastructure.Authentication.Library;

internal record struct JwtTokenOptions(SigningCredentials SigningCredentials, string ValidIssuer, string ValidAudience, Claim[] Claims)
{
    public static DateTime Expiration => DateTime.Now.AddHours(1);
}
