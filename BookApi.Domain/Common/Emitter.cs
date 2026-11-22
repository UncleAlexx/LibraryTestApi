namespace Library.Domain.Common.Extensions;

public static class Emitter
{
    public static TDelegate EmitCall<TDelegate>(MethodBase methodBase, Type[] parameters) where TDelegate : Delegate
    {
        if (methodBase is null)
            return null!;
        var _ = methodBase is MethodInfo methodInfo;
        Unsafe.SkipInit(out methodInfo);
        DynamicMethod method = new("", methodInfo?.ReturnType?? methodBase.ReflectedType, parameters);
        var il = method.GetILGenerator();
        for (int i = 0; i < parameters.Length; i++)
            il.Emit(OpCodes.Ldarga_S, i);
        switch (methodBase)
        {
            case MethodInfo: il.Emit(OpCodes.Call, methodInfo!); break;
            case ConstructorInfo: il.Emit(OpCodes.Newobj, Unsafe.As<MethodBase, ConstructorInfo>(ref methodBase)); break;
            default: return null!;
        }
        il.Emit(OpCodes.Ret);
        return method.CreateDelegate<TDelegate>();
    }
}
