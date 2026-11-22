namespace Library.Domain.Common.Validation;

public readonly struct Bounds<TLimit> where TLimit : struct, IComparable<TLimit>
{
    public readonly TLimit Max;
    public readonly TLimit Min;

    private const string GuardMessage = "Max should be >= Min";
    public Bounds(TLimit min, TLimit max)
    {
        (Max, Min) = (max, min);
        GreaterThanOrEqualGuard();
    }

    public Bounds() => GreaterThanOrEqualGuard();

    public bool InRange(in TLimit instance) => (instance.CompareTo(Min) | Max.CompareTo(instance)) >= 0;

    private void GreaterThanOrEqualGuard() => Trace.Assert(Max.CompareTo(Min) >= 0, GuardMessage);
}
