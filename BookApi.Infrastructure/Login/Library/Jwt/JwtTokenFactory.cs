using Library.Infrastructure.Authentication.Library;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace BookApi.Infrastructure.Authentication.Library.Jwt;
public sealed class JwtTokenFactory
{
    private readonly SigningCredentials _signingCredentials;
    private readonly JwtTokenOptions? _tokenOptions;

    private static readonly Claim[] _userClaims = [new(LibraryUserClaimType.Name, ""), new(LibraryUserClaimType.Email, ""), new(LibraryUserClaimType.Password, ""),
        new(LibraryUserClaimType.Secret, "")];
    private static readonly JwtSecurityTokenHandler _tokenHandler = new();

    public JwtTokenFactory(IOptions<JwtBearerOptions> options)
    {
        JwtBearerOptions bearerOptions = options.Value;
        _signingCredentials = new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(bearerOptions?.IssuerSigningKey ?? "")), SecurityAlgorithms.HmacSha256);
        _tokenOptions = new(_signingCredentials, bearerOptions?.ValidIssuer ?? "", bearerOptions?.ValidAudience ?? "", _userClaims);
    }

    public string CreateToken(string name, string password, string email, string secret)
    {
        _userClaims[0] = new(_userClaims[0].Type, name);
        _userClaims[1] = new(_userClaims[1].Type, password);
        _userClaims[2] = new(_userClaims[2].Type, email);
        _userClaims[3] = new(_userClaims[3].Type, (HttpUtility.UrlDecode(secret).Replace(' ', '+')));
        var tk = new JwtSecurityToken(_tokenOptions?.ValidIssuer ?? "", _tokenOptions?.ValidAudience ?? "", _tokenOptions?.Claims ?? [], null,
            signingCredentials: _signingCredentials);
        return _tokenHandler.WriteToken(tk);
    }
}
