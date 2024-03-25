namespace Library.Domain.Common.Abstractions.ValueObjects;

public abstract class GuidObject<TGuidObject> : ValueObject<Guid, TGuidObject, TGuidObject>
     where TGuidObject : GuidObject<TGuidObject>
{
    protected private new static readonly ConstructorInfo TInstanceCtor = typeof(TGuidObject).GetConstructor(
        BindingFlags.NonPublic | BindingFlags.Instance, [typeof(Guid).MakeByRefType()])!;
    protected private new static readonly Func<Guid, TGuidObject> TInstance = Emitter.EmitCall<Func<Guid, TGuidObject>>
        (TInstanceCtor, [typeof(Guid)])!;
    private static readonly MethodInfo _createUniqueBaseInfo = typeof(TGuidObject).GetMethod(nameof(CreateUniqueBase),
        BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy)!;
    private static readonly Func<TGuidObject> _createUniqueBaseMethod = Emitter.EmitCall<Func<TGuidObject>>(_createUniqueBaseInfo, [])!;

    protected private GuidObject(in Guid value) : base(value, true) { }

    public static TGuidObject CreateUnique() => _createUniqueBaseMethod();

    protected private static new TGuidObject CreateBase(in Guid value) => TInstance(value);

    protected private static TGuidObject CreateUniqueBase() => TInstance(Guid.NewGuid());
}