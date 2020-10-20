namespace CJBasic.Emit.ForEntity
{
    using System;
    using System.Collections.Generic;

    public static class DynamicEntityFactory
    {
        private static Dictionary<string, Type> EntityDic = new Dictionary<string, Type>();
        private static DynamicEntityEmitter EntityEmitter = new DynamicEntityEmitter(false);

        public static Type CreateEntityType(string entityTypeName, IDictionary<string, Type> entityPropertyDic, Type parentInterfaceType)
        {
            lock (EntityEmitter)
            {
                if (!EntityDic.ContainsKey(entityTypeName))
                {
                    Type type = EntityEmitter.EmitEntityType(entityTypeName, entityPropertyDic, parentInterfaceType);
                    EntityDic.Add(entityTypeName, type);
                }
                return EntityDic[entityTypeName];
            }
        }
    }
}

