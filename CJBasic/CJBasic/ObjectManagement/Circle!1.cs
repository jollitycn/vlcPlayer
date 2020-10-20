namespace CJBasic.ObjectManagement
{
    using System;
    using System.Collections.Generic;

    public class Circle<T>
    {
        private int currentPosition;
        private IList<T> list;

        public Circle()
        {
            this.list = new List<T>();
            this.currentPosition = 0;
        }

        public Circle(IList<T> _list)
        {
            this.list = new List<T>();
            this.currentPosition = 0;
            if (_list != null)
            {
                this.list = _list;
            }
        }

        public void Append(T obj)
        {
            this.list.Add(obj);
        }

        public void InsertAt(T obj, int postionIndex)
        {
            if (this.list.Count == 0)
            {
                this.list.Add(obj);
            }
            else
            {
                int index = postionIndex % this.list.Count;
                this.list.Insert(index, obj);
                if (index <= this.currentPosition)
                {
                    this.currentPosition++;
                }
            }
        }

        public void MoveBack()
        {
            if (this.list.Count != 0)
            {
                this.currentPosition = ((this.currentPosition + this.list.Count) - 1) % this.list.Count;
            }
        }

        public void MoveNext()
        {
            if (this.list.Count != 0)
            {
                this.currentPosition = (this.currentPosition + 1) % this.list.Count;
            }
        }

        public T PeekBack()
        {
            this.MoveBack();
            T current = this.Current;
            this.MoveNext();
            return current;
        }

        public T PeekNext()
        {
            this.MoveNext();
            T current = this.Current;
            this.MoveBack();
            return current;
        }

        public void RemoveAt(int postionIndex)
        {
            if (this.list.Count != 0)
            {
                int index = postionIndex % this.list.Count;
                this.list.RemoveAt(index);
                if (index < this.currentPosition)
                {
                    this.currentPosition--;
                }
            }
        }

        public void RemoveTail()
        {
            if (this.list.Count != 0)
            {
                this.RemoveAt(this.list.Count - 1);
            }
        }

        public void SetCurrent(T val)
        {
            if (!this.Current.Equals(val))
            {
                for (int i = 0; i < this.list.Count; i++)
                {
                    T local = this.list[i];
                    if (local.Equals(val))
                    {
                        this.currentPosition = i;
                        break;
                    }
                }
            }
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public T Current
        {
            get
            {
                if (this.list.Count == 0)
                {
                    return default(T);
                }
                return this.list[this.currentPosition];
            }
        }

        public T Header
        {
            get
            {
                if (this.list.Count == 0)
                {
                    return default(T);
                }
                return this.list[0];
            }
        }

        public T Tail
        {
            get
            {
                if (this.list.Count == 0)
                {
                    return default(T);
                }
                return this.list[this.list.Count - 1];
            }
        }
    }
}

