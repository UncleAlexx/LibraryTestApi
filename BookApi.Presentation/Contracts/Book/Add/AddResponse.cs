namespace Library.Presentation.Contracts.Book.Add;

internal sealed record AddResponse<T>(DateTime Date, string Route, T Inserted, ushort Code = 200) : 
    ResponseBase<T>(Date, Route, Code);