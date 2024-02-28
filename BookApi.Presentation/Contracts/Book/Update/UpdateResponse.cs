
using BookApi.Presentation.Contracts.Book.Common.Bases;

internal record UpdateResponse<T>(DateTime Date, string Route, T Inserted, T Deleted,  ushort Code = 200) 
    : ResponseBase<T>(Date, Route, Code);