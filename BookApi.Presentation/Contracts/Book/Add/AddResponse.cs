
using BookApi.Presentation.Contracts.Book.Common.Bases;

internal record AddResponse<T>(DateTime Date, string Route, T Inserted, ushort Code=200) : ResponseBase<T>(Date, Route, Code);