namespace Library.Presentation.Contracts.Book.Common;

internal sealed record EntitiesResponse<T>(DateTime Date, string Route, IEnumerable<T> Entity, ushort Code = 200) : 
    ResponseBase<T>(Date, Route, Code);