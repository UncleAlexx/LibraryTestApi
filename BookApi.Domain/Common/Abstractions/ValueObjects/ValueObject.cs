﻿namespace Library.Domain.Common.Abstractions.ValueObjects;

public abstract class ValueObject<TValue, TValueObject, TCreateType> : IEquatable<ValueObject<TValue, TValueObject, 
    TCreateType>>, IEqualityOperators<ValueObject<TValue, TValueObject, TCreateType>, ValueObject<TValue, TValueObject,
    TCreateType>, bool>, IValueObject<TValue, TCreateType> 
    where TValueObject : ValueObject<TValue, TValueObject, TCreateType> where TValue : IEquatable<TValue>
{
    private readonly static Type[] _ctorParams = [typeof(TValue), typeof(bool)];
    private static Type[] _inctorParams = Array.ConvertAll(_ctorParams, param => param.MakeByRefType());

    protected private static readonly ConstructorInfo TInstanceCtor = typeof(TValueObject).GetConstructor
        (BindingFlags.Instance | BindingFlags.NonPublic, _inctorParams)!;
    protected private static readonly OptionalFunc<TValue, TValueObject> TInstance =
        Emitter.EmitCall<OptionalFunc<TValue, TValueObject>>(TInstanceCtor, _ctorParams)!;

    private static readonly MethodInfo _createBaseInfo =
        typeof(TValueObject).GetMethod(nameof(CreateBase), BindingFlags.NonPublic | BindingFlags.Static | 
            BindingFlags.FlattenHierarchy)!;
    private static readonly Func<TValue, TCreateType> _createBaseMethod = 
        Emitter.EmitCall<Func<TValue, TCreateType>>(_createBaseInfo, [typeof(TValue)]);
    protected ValueObject(in TValue value, in bool success) => (Value, ErrorMessage) = (value, success ? "" : ErrorMessage!);

    [MaybeNull, JsonIgnore]
    public static string PropertyName { get; }
    [JsonIgnore]
    public virtual string ErrorMessage { get; init; } = "";
    public TValue Value { get; init; }

    public static TCreateType Create(in TValue value) => _createBaseMethod(value);

    protected private static TCreateType CreateBase(in TValue value) => throw new NotImplementedException();

    public override sealed string ToString() => $"{Value}";

    public override sealed int GetHashCode() => Value.GetHashCode();

    public override sealed bool Equals(object? obj) => obj is ValueObject<TValue, TValueObject, TCreateType> 
        other && other == this;

    public bool Equals(ValueObject<TValue, TValueObject, TCreateType>? other) => other == this;

    public static bool operator == (ValueObject<TValue, TValueObject, TCreateType>? left, 
        ValueObject<TValue, TValueObject, TCreateType>? right) => (left, right) is not (null, null)
        and not ({ Value: null }, { Value: null }) && left!.Value!.Equals(right!.Value);

    public static bool operator != (ValueObject<TValue, TValueObject, TCreateType>? left, 
        ValueObject<TValue, TValueObject, TCreateType>? right) => (left == right) is false;
}