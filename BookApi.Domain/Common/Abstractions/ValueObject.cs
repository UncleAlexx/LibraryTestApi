namespace Library.Domain.Common.Abstractions;

public abstract record ValueObject<T,T2> where T2 : ValueObject<T,T2>
{
    public static ConstructorInfo _fieldInfo = typeof(ValueObject<T, T2>).GetConstructor(BindingFlags.Instance |
        BindingFlags.NonPublic, [typeof(T)]);
    public static readonly Func<T, T2> hhj;

    protected ValueObject(T value) => Value = value;

    static ValueObject()
    {
        static Func<T, T2> f2s()
        {
            DynamicMethod dynamic = new("", typeof(T2), [typeof(T)]);
            var a = dynamic.GetILGenerator();
            a.Emit(OpCodes.Ldarg_S, 0);
            a.Emit(OpCodes.Newobj, _fieldInfo);
            a.Emit(OpCodes.Ret);
            return dynamic.CreateDelegate<Func<T, T2>>();
        }
        hhj = f2s();
    }
    public T Value { get; init; }

    public static T2? Create<T2>(Regex regex, string value) where T2 : ValueObject<string, T2> =>
        value is not null or "" && regex.IsMatch(value!) ? ValueObject<string, T2>.hhj(value) : null;
}
