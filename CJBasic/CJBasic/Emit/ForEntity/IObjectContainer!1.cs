namespace CJBasic.Emit.ForEntity
{
    using System;

    public interface IObjectContainer<TEntity>
    {
        void Add(TEntity entity);
    }
}

