namespace Library.Presentation.Contracts.Book.Common;

internal sealed record EntitiesResponse<TEntity>(DateTime Date, string Route, IEnumerable<TEntity> Entity, 
    string HttpMethod = nameof(HttpMethod.Get), ushort Code = 200) : ResponseBase<TEntity>(Date, Route, HttpMethod, Code);