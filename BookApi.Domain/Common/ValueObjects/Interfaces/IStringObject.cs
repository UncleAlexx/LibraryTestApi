namespace Library.Domain.Common.ValueObjects.Interfaces;

internal interface IStringObject<TRet> : IValueObject<string, TRet>
{
    abstract Bounds<int> Bounds { get; }
    bool Default { get; }

    abstract bool IsMatch();
    Regex Pattern();
}