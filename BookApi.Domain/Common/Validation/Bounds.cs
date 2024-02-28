namespace BookApi.Domain.Common.Validation;

public readonly struct Bounds<T>(T min, T max) where T : struct
{
    public readonly T Max = max;
    public readonly T Min = min;
}

