using BookApi.Domain.Book;
using BookApi.Presentation.Contracts.Book.Common.Bases;

internal record EntitiesResponse<T>(DateTime Date, string Route, IEnumerable<T> Entity, ushort Code = 200) : ResponseBase<T>(Date, Route, Code);