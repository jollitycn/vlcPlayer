namespace CJBasic.ObjectManagement.Managers
{
    public interface IGroupingObject<TGroupKey, TObjectKey>
    {
        TGroupKey GroupID { get; }

        TObjectKey ID { get; }
    }
}

