namespace Library.Presentation.Contracts.Book.Update;

internal sealed record UpdateResponse<T>(DateTime Date, string Route, T Inserted, T Deleted,  ushort Code = 200) 
    : ResponseBase<T>(Date, Route, Code);