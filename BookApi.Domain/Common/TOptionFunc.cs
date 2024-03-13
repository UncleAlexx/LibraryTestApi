namespace Library.Domain.Common;

public delegate TResult OptionalFunc<in TArg, out TResult>(TArg arg, bool optionalArg = true);