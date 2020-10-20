namespace CJBasic.Collections
{
    using System;
    using System.Collections.Generic;

    public class DispersiveKeyScope
    {
        private IList<KeyScope> dispersiveKeyScopeList = new List<KeyScope>();
        private SortedArray<int> dispersiveKeySortedArray = new SortedArray<int>();

        public void Add(int val)
        {
            this.dispersiveKeySortedArray.Add(val);
        }

        public bool Contains(int val)
        {
            Predicate<KeyScope> predicate = null;
            bool flag = this.dispersiveKeySortedArray.Contains(val);
            if (flag)
            {
                return flag;
            }
            if (predicate == null)
            {
                predicate = delegate (KeyScope scope) {
                    return scope.Contains(val);
                };
            }
            return CollectionHelper.ContainsSpecification<KeyScope>(this.dispersiveKeyScopeList, predicate);
        }

        public ICollection<int> DispersiveKeyList
        {
            set
            {
                this.dispersiveKeySortedArray = new SortedArray<int>(value);
            }
        }

        public IList<KeyScope> DispersiveKeyScopeList
        {
            set
            {
                if (value == null)
                {
                    this.dispersiveKeyScopeList = new List<KeyScope>();
                }
                else
                {
                    this.dispersiveKeyScopeList = value;
                }
            }
        }
    }
}

