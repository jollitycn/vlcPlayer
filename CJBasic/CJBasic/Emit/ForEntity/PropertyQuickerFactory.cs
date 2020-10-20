namespace CJBasic.Emit.ForEntity
{
    using System;
    using System.Collections.Generic;

    public static class PropertyQuickerFactory
    {
        private static Dictionary<Type, IPropertyQuicker> PropertyQuickerDic = new Dictionary<Type, IPropertyQuicker>();
        private static CJBasic.Emit.ForEntity.PropertyQuickerEmitter PropertyQuickerEmitter = new CJBasic.Emit.ForEntity.PropertyQuickerEmitter(false);
        private static CJBasic.Emit.ForEntity.RelectPropertyQuicker RelectPropertyQuicker = new CJBasic.Emit.ForEntity.RelectPropertyQuicker();

        public static IPropertyQuicker<TEntity> CreatePropertyQuicker<TEntity>()
        {
            return (IPropertyQuicker<TEntity>) CreatePropertyQuicker(typeof(TEntity));
        }

        public static IPropertyQuicker CreatePropertyQuicker(Type entityType)
        {
            if (entityType.IsGenericType)
            {
                return RelectPropertyQuicker;
            }
            lock (PropertyQuickerEmitter)
            {
                if (!PropertyQuickerDic.ContainsKey(entityType))
                {
                    IPropertyQuicker quicker = (IPropertyQuicker) Activator.CreateInstance(PropertyQuickerEmitter.CreatePropertyQuickerType(entityType));
                    PropertyQuickerDic.Add(entityType, quicker);
                }
                return PropertyQuickerDic[entityType];
            }
        }
    }
}

