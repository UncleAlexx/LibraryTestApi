namespace Library.Domain.Common.Persistence.Dapper.Abstractions;

internal abstract class QueryParameter<TParameter, TValue> where TParameter : QueryParameter<TParameter, TValue>
{
    [MaybeNull]
    protected private TValue BackingField;

    private static readonly ConstructorInfo _ctorInfo = typeof(TParameter).
        GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, [])!;

    public readonly static TParameter Instance = Emitter.EmitCall<Func<TParameter>>(_ctorInfo, [])!();
}