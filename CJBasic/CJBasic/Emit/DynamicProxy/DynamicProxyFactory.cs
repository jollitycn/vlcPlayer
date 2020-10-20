namespace CJBasic.Emit.DynamicProxy
{
    using System;

    public static class DynamicProxyFactory
    {
        private static CJBasic.Emit.DynamicProxy.EfficientAopProxyEmitter EfficientAopProxyEmitter = new CJBasic.Emit.DynamicProxy.EfficientAopProxyEmitter(false);

        public static TInterface CreateEfficientAopProxy<TInterface>(object origin, IAopInterceptor aopInterceptor)
        {
            lock (EfficientAopProxyEmitter)
            {
                Type originType = origin.GetType();
                return (TInterface) EfficientAopProxyEmitter.EmitProxyType<TInterface>(originType).GetConstructor(new Type[] { originType, typeof(IAopInterceptor) }).Invoke(new object[] { origin, aopInterceptor });
            }
        }

        public static TInterface CreateEfficientAopProxy<TInterface>(TInterface origin, IAopInterceptor aopInterceptor)
        {
            lock (EfficientAopProxyEmitter)
            {
                Type originType = typeof(TInterface);
                return (TInterface) EfficientAopProxyEmitter.EmitProxyType<TInterface>(originType).GetConstructor(new Type[] { originType, typeof(IAopInterceptor) }).Invoke(new object[] { origin, aopInterceptor });
            }
        }

        public static object CreateEfficientAopProxy(Type proxyIntfaceType, object origin, IAopInterceptor aopInterceptor)
        {
            lock (EfficientAopProxyEmitter)
            {
                Type originType = origin.GetType();
                return EfficientAopProxyEmitter.EmitProxyType(proxyIntfaceType, originType).GetConstructor(new Type[] { originType, typeof(IAopInterceptor) }).Invoke(new object[] { origin, aopInterceptor });
            }
        }
    }
}

