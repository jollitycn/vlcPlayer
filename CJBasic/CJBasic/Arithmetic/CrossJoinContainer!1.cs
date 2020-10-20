namespace CJBasic.Arithmetic
{
    using System;
    using System.Collections.Generic;

    public class CrossJoinContainer<T> where T: ICrossJoinable<T>
    {
        private List<T> elementList;

        public CrossJoinContainer()
        {
            this.elementList = new List<T>();
        }

        public void Join(List<T> list)
        {
            if ((list != null) && (list.Count != 0))
            {
                if ((this.elementList == null) || (this.elementList.Count == 0))
                {
                    this.elementList = list;
                }
                else
                {
                    List<T> elementList = this.elementList;
                    List<T> list3 = new List<T>();
                    foreach (T local in elementList)
                    {
                        foreach (T local2 in list)
                        {
                            list3.Add(local.CrossJoin(local2));
                        }
                    }
                    this.elementList = list3;
                }
            }
        }

        public List<T> ElementList
        {
            get
            {
                return this.elementList;
            }
        }
    }
}

