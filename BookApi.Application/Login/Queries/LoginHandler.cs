namespace Library.Application.Login.Queries;

public sealed class LoginHandler(IValidator<BookView> validator, JwtTokenFactory login) : IQueryHandler<Login, string, MessageResult<string>>
{
    private readonly JwtTokenFactory _login = login;

    public Task<MessageResult<string>> Handle(Login request, CancellationToken cancellationToken)
    {
        return Task.FromResult(MessageResult<string>.Success(_login.CreateToken(request.Name, request.Password, request.Email, request.Secret)));
    }
}
