namespace CJBasic.Emit.ForEntity
{
    using CJBasic.Helpers;
    using System;

    internal class RelectPropertyQuicker : IPropertyQuicker
    {
        public object GetValue(object entity, string propertyName)
        {
            return ReflectionHelper.GetProperty(entity, propertyName);
        }

        public void SetValue(object entity, string propertyName, object propertyValue)
        {
            ReflectionHelper.SetProperty(entity, propertyName, propertyValue);
        }
    }
}

