namespace Library.Presentation.Contracts.Book.Update;

internal sealed record UpdateResponse<TEntity>(DateTime Date, string Route, TEntity Updated, 
    ushort Code = 200) : ResponseBase<TEntity>(Date, Route, Code);