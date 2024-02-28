namespace BookApi.Application.Login;

public record JwtOptions
{
    [Required] public bool ValidateIssuer { get; init; }
    [Required] public bool ValidateAudience { get; init; }
    [Required] public bool ValidateLifetime { get; init; }
    [Required] public bool ValidateIssuerSigningKey { get; init; }
    [Required] public string ValidIssuer { get; init; }
    [Required] public string ValidAudience { get; init; }
    [Required] public string IssuerSigningKey { get; init; }
}