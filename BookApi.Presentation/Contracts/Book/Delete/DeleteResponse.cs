namespace Library.Presentation.Contracts.Book.Delete;

internal sealed record DeleteResponse<TEntity>(DateTime Date, string Route, TEntity Deleted, ushort Code = 200) : 
    ResponseBase<TEntity>(Date, Route, Method, Code)
{
    const string Method = nameof(HttpMethods.Delete);
}