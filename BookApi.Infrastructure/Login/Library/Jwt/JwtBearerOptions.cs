namespace Library.Infrastructure.Login.Library.Jwt;

public sealed class JwtBearerOptions
{
    [MaybeNull] private readonly string _issuerSigningKey;

    [Required] public required bool ValidateIssuer { get; init; }
    [Required] public required bool ValidateAudience { get; init; }
    [Required] public required bool ValidateLifetime { get; init; }
    [Required] public required bool ValidateIssuerSigningKey { get; init; }
    [Required, MaybeNull] public required string ValidIssuer { get; init; }
    [Required, MaybeNull] public required string ValidAudience { get; init; }
    [Required, MaybeNull] public required string IssuerSigningKey { get => _issuerSigningKey; 
        init => _issuerSigningKey = WebUtility.UrlEncode(value)!.Replace("%2B", "+");
    }
}