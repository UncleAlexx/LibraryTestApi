using System.Security.Claims;
namespace BookApi.Infrastructure.Authentication.Library;

public static class LibraryUserClaimType
{
    public const string Name = ClaimTypes.Name;
    public const string Password = "Password";
    public const string Email = ClaimTypes.Email;
    public const string Secret = "Secret";
}