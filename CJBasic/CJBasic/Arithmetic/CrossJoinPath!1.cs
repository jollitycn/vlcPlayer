namespace CJBasic.Arithmetic
{
    using System;
    using System.Collections.Generic;

    public class CrossJoinPath<T>
    {
        private List<T> path;

        public CrossJoinPath(T t)
        {
            this.path = new List<T>();
            this.path.Add(t);
        }

        public CrossJoinPath(List<T> _path)
        {
            this.path = new List<T>();
            this.path = _path;
        }

        public CrossJoinPath<T> CrossJoin(T t)
        {
            List<T> list = new List<T>();
            foreach (T local in this.path)
            {
                list.Add(local);
            }
            list.Add(t);
            return new CrossJoinPath<T>(list);
        }

        public List<T> Path
        {
            get
            {
                return this.path;
            }
        }
    }
}

