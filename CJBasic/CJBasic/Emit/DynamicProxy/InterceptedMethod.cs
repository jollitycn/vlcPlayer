namespace CJBasic.Emit.DynamicProxy
{
    using System;

    public sealed class InterceptedMethod
    {
        private string[] argumentNames;
        private object[] argumentValues;
        private Type[] genericTypes;
        private string methodName;
        private object target;

        public InterceptedMethod()
        {
            this.genericTypes = null;
        }

        public InterceptedMethod(object _target, string _method, Type[] _genericTypes, string[] paraNames, object[] paraValues)
        {
            this.genericTypes = null;
            this.target = _target;
            this.methodName = _method;
            this.genericTypes = _genericTypes;
            this.argumentNames = paraNames;
            this.argumentValues = paraValues;
        }

        public string[] ArgumentNames
        {
            get
            {
                return this.argumentNames;
            }
            set
            {
                this.argumentNames = value;
            }
        }

        public object[] ArgumentValues
        {
            get
            {
                return this.argumentValues;
            }
            set
            {
                this.argumentValues = value;
            }
        }

        public Type[] GenericTypes
        {
            get
            {
                return this.genericTypes;
            }
            set
            {
                this.genericTypes = value;
            }
        }

        public string MethodName
        {
            get
            {
                return this.methodName;
            }
            set
            {
                this.methodName = value;
            }
        }

        public object Target
        {
            get
            {
                return this.target;
            }
            set
            {
                this.target = value;
            }
        }
    }
}

