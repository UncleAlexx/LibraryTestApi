namespace Library.Presentation.Contracts.Book.Common;

internal sealed record EntityResponse<TEntity>(DateTime Date, string Route, TEntity Entity, ushort Code = 200) : 
    ResponseBase<TEntity>(Date, Route, Code);