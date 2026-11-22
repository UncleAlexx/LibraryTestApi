namespace Library.Domain.Common.ValueObjects.Interfaces;

internal interface IDateObject<TRet> : IValueObject<DateTime, TRet>
{
    abstract Bounds<DateTime> Bounds { get; }
}