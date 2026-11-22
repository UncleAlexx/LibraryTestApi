namespace Library.Presentation.Contracts.Book.Common.Bases;

internal abstract record ResponseBase<T>(in DateTime Date, in string Route, in string HttpMethod = nameof(HttpMethods.Get), 
    in ushort Code = 200);