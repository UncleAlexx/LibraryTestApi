namespace Library.Domain.Common.Validation;

public readonly struct Bounds<TLimit>(in TLimit min, in TLimit max) where TLimit : struct, IComparable<TLimit>
{
    public readonly TLimit Max = max;
    public readonly TLimit Min = min;

    public bool InRange(in TLimit instance) => instance.CompareTo(Min) >= 0 && instance.CompareTo(Max) <= 0;
}