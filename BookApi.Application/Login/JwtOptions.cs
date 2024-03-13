namespace Library.Application.Login;

internal sealed record JwtOptions
{
    [Required] public required bool ValidateIssuer { get; init; }
    [Required] public required bool ValidateAudience { get; init; }
    [Required] public required bool ValidateLifetime { get; init; }
    [Required] public required bool ValidateIssuerSigningKey { get; init; }
    [Required] public required string ValidIssuer { get; init; }
    [Required] public required string ValidAudience { get; init; }
    [Required] public required string IssuerSigningKey { get; init; }
}