namespace CJBasic.Arithmetic
{
    using System;
    using System.Collections.Generic;

    public class SimpleCrossJoiner<T>
    {
        private List<CrossJoinPath<T>> result;

        public void CrossJoin(ICollection<T> collection)
        {
            if ((collection != null) && (collection.Count != 0))
            {
                if (this.result == null)
                {
                    this.result = new List<CrossJoinPath<T>>();
                    foreach (T local in collection)
                    {
                        this.result.Add(new CrossJoinPath<T>(local));
                    }
                }
                else
                {
                    List<CrossJoinPath<T>> list = new List<CrossJoinPath<T>>();
                    foreach (CrossJoinPath<T> path in this.result)
                    {
                        foreach (T local in collection)
                        {
                            list.Add(path.CrossJoin(local));
                        }
                    }
                    this.result = list;
                }
            }
        }

        public List<CrossJoinPath<T>> Result
        {
            get
            {
                return this.result;
            }
        }
    }
}

