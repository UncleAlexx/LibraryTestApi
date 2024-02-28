namespace BookApi.Application.Login.Queries;

public sealed record Login(string Name, string Email, string Password, string Secret) : IQuery<string, MessageResult<string>>;
