namespace Library.Domain.Common;

public delegate TRet OptionalFunc<TArg, out TRet>(TArg arg, bool optionalArg = true);