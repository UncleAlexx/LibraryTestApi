namespace Library.Presentation.Contracts.Book.Delete;

internal sealed record DeleteResponse<TEntity>(DateTime Date, string Route, TEntity Deleted, TEntity Inserted, ushort Code = 200) : 
    ResponseBase<TEntity>(Date, Route, Code);