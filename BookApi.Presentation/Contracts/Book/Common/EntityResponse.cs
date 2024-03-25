namespace Library.Presentation.Contracts.Book.Common;

internal sealed record EntityResponse<TEntity>(DateTime Date, string Route, TEntity Entity, 
    string HttpMethod = nameof(HttpMethod.Get), ushort Code = 200) : ResponseBase<TEntity>(Date, Route, HttpMethod, Code);