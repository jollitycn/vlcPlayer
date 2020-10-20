namespace CJBasic.Emit.ForEntity
{
    using System;

    public interface IPropertyQuicker<TEntity> : IPropertyQuicker
    {
        object GetPropertyValue(TEntity entity, string propertyName);
        void SetPropertyValue(TEntity entity, string propertyName, object propertyValue);
    }
}

