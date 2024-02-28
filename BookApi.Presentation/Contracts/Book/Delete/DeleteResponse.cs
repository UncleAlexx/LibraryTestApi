using BookApi.Presentation.Contracts.Book.Common.Bases;

namespace BookApi.Presentation.Contracts.Book.Delete;

internal record DeleteResponse<T>(DateTime Date, string Route, T Deleted, T Inserted, ushort Code = 200) : ResponseBase<T>(Date, Route, Code);