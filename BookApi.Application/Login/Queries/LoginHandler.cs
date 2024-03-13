namespace Library.Application.Login.Queries;

internal sealed class LoginHandler(JwtTokenFactory login) : IQueryHandler<Login, string, 
    MessageResult<string>>
{
    private readonly JwtTokenFactory _login = login;

    public Task<MessageResult<string>> Handle(Login request, CancellationToken cancellationToken) =>
        Task.FromResult(MessageResult<string>.Success(_login.CreateToken(request.Name, request.Password, request.Email, 
            request.Secret)));
}
