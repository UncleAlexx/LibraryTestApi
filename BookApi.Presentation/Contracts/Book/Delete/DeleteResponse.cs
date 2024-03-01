namespace Library.Presentation.Contracts.Book.Delete;

internal sealed record DeleteResponse<T>(DateTime Date, string Route, T Deleted, T Inserted, ushort Code = 200) : 
    ResponseBase<T>(Date, Route, Code);