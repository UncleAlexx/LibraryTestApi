using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BookApi.Infrastructure.Authentication.Library.Jwt;

public sealed class JwtBearerOptions
{
    [Required] public required bool ValidateIssuer { get; init; }
    [Required] public required bool ValidateAudience { get; init; }
    [Required] public required bool ValidateLifetime { get; init; }
    [Required] public required bool ValidateIssuerSigningKey { get; init; }
    [Required, MaybeNull] public required string ValidIssuer { get; init; }
    [Required, MaybeNull] public required string ValidAudience { get; init; }
    [Required, MaybeNull] public required string IssuerSigningKey { get; init; }
}