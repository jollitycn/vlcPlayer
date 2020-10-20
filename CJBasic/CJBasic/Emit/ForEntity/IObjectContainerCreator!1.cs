namespace CJBasic.Emit.ForEntity
{
    public interface IObjectContainerCreator<TEntity>
    {
        IObjectContainer<TEntity> CreateNewContainer();
    }
}

