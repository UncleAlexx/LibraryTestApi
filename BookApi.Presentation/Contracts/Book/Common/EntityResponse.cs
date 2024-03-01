namespace Library.Presentation.Contracts.Book.Common;

internal record EntityResponse<T>(DateTime Date, string Route, T Entity, ushort Code = 200) : 
    ResponseBase<T>(Date, Route, Code);