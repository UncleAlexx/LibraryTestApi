namespace Library.Presentation.Contracts.Book.Add;

internal sealed record AddResponse<TEntity>(DateTime Date, string Route, TEntity Inserted,
    ushort Code = 200) : ResponseBase<TEntity>(Date, Route, Method, Code)
{
    private const string Method = nameof(HttpMethods.Post);
}