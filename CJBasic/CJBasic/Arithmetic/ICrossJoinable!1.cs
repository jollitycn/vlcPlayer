namespace CJBasic.Arithmetic
{
    public interface ICrossJoinable<T> where T: ICrossJoinable<T>
    {
        T CrossJoin(T other);
    }
}

