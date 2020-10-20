namespace CJBasic.Emit.ForEntity
{
    using System;

    public interface IPropertyQuicker
    {
        object GetValue(object entity, string propertyName);
        void SetValue(object entity, string propertyName, object propertyValue);
    }
}

