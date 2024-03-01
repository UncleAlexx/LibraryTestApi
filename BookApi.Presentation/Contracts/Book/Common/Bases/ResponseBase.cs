namespace Library.Presentation.Contracts.Book.Common.Bases;

internal abstract record ResponseBase<T>(DateTime Date, string Route, ushort Code = 200);

