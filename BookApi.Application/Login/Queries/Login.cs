namespace Library.Application.Login.Queries;

internal sealed record Login(in string Name, in string Email, in string Password, in string Secret): 
    IQuery<string, MessageResult<string>>;
