namespace CJPlus.Application.CustomizeInfo
{
    using CJBasic.Collections;
    using System;
    using System.Collections.Generic;

    public class ComplexCustomizeHandler : ICustomizeHandler, IIntegratedCustomizeHandler
    {
        private IList<IIntegratedCustomizeHandler> ilist_0;
        private object object_0;
        private SortedArray<int, IIntegratedCustomizeHandler> sortedArray_0;

        public ComplexCustomizeHandler()
        {
            this.sortedArray_0 = new SortedArray<int, IIntegratedCustomizeHandler>();
            this.object_0 = new object();
            this.ilist_0 = new List<IIntegratedCustomizeHandler>();
        }

        public ComplexCustomizeHandler(IIntegratedCustomizeHandler singleHandler)
        {
            this.sortedArray_0 = new SortedArray<int, IIntegratedCustomizeHandler>();
            this.object_0 = new object();
            this.ilist_0 = new List<IIntegratedCustomizeHandler>();
            this.ilist_0 = new List<IIntegratedCustomizeHandler>();
            this.ilist_0.Add(singleHandler);
        }

        public ComplexCustomizeHandler(IEnumerable<IIntegratedCustomizeHandler> handlers)
        {
            this.sortedArray_0 = new SortedArray<int, IIntegratedCustomizeHandler>();
            this.object_0 = new object();
            this.ilist_0 = new List<IIntegratedCustomizeHandler>();
            this.ilist_0 = new List<IIntegratedCustomizeHandler>(handlers);
        }

        public ComplexCustomizeHandler(params IIntegratedCustomizeHandler[] handlers)
        {
            this.sortedArray_0 = new SortedArray<int, IIntegratedCustomizeHandler>();
            this.object_0 = new object();
            this.ilist_0 = new List<IIntegratedCustomizeHandler>();
            this.ilist_0 = new List<IIntegratedCustomizeHandler>(handlers);
        }

        public bool CanHandle(int informationType)
        {
            return (this.method_0(informationType) != null);
        }

        public void HandleInformation(string sourceUserID, int informationType, byte[] info)
        {
            IIntegratedCustomizeHandler handler = this.method_0(informationType);
            if (handler == null)
            {
                throw new Exception(string.Format("The Information Handler On Type [{0}] is not found !", informationType));
            }
            handler.HandleInformation(sourceUserID, informationType, info);
        }

        public byte[] HandleQuery(string sourceUserID, int informationType, byte[] info)
        {
            IIntegratedCustomizeHandler handler = this.method_0(informationType);
            if (handler == null)
            {
                throw new Exception(string.Format("The Information Handler On Type [{0}] is not found !", informationType));
            }
            return handler.HandleQuery(sourceUserID, informationType, info);
        }

        private IIntegratedCustomizeHandler method_0(int int_0)
        {
            if (this.sortedArray_0.ContainsKey(int_0))
            {
                return this.sortedArray_0[int_0];
            }
            IIntegratedCustomizeHandler val = null;
            using (IEnumerator<IIntegratedCustomizeHandler> enumerator = this.ilist_0.GetEnumerator())
            {
                IIntegratedCustomizeHandler current;
                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (current.CanHandle(int_0))
                    {
                        goto Label_004F;
                    }
                }
                goto Label_0060;
            Label_004F:
                val = current;
            }
        Label_0060:
            if (val != null)
            {
                lock (this.object_0)
                {
                    if (!this.sortedArray_0.ContainsKey(int_0))
                    {
                        this.sortedArray_0.Add(int_0, val);
                    }
                }
            }
            return val;
        }

        public IList<IIntegratedCustomizeHandler> HandlerList
        {
            set
            {
                this.ilist_0 = value;
            }
        }
    }
}

