using System;
using System.Reflection;
using System.Runtime.CompilerServices;

internal class Class166
{
    internal static Module module_0 = typeof(Class166).Assembly.ManifestModule;

    internal static void QX6NJo77vGbUZ(int typemdt)
    {
        Type type = module_0.ResolveType(0x2000000 + typemdt);
        foreach (FieldInfo info in type.GetFields())
        {
            MethodInfo method = (MethodInfo) module_0.ResolveMethod(info.MetadataToken + 0x6000000);
            info.SetValue(null, (MulticastDelegate) Delegate.CreateDelegate(type, method));
        }
    }

    internal delegate void Delegate2(object o);
}

