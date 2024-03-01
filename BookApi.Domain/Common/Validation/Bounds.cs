namespace Library.Domain.Common.Validation;

public readonly struct Bounds<T>(in T min, in T max) where T : struct
{
    public readonly T Max = max;
    public readonly T Min = min;
}

