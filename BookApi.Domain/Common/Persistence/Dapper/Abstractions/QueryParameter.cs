namespace Library.Domain.Common.Persistence.Dapper.Abstractions;

public abstract class QueryParameter<T> where T : QueryParameter<T>
{
    private static readonly ConstructorInfo _ctorInfo = typeof(T).
        GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, [])!;

    static QueryParameter()
    {
        static T InitInstance()
        {
            DynamicMethod f = new(string.Empty, typeof(T), []);
            var info = f.GetILGenerator();
            info.Emit(OpCodes.Newobj, _ctorInfo);
            info.Emit(OpCodes.Ret);
            return f.CreateDelegate<Func<T>>()();
        }
        Instance = InitInstance();
    }

    public readonly static T Instance;
}