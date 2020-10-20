namespace CJBasic.ObjectManagement.Managers
{
    using System;

    [Serializable]
    public class PriorityManagerPara
    {
        private CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow actionTypeOnAddOverflow;
        private int capacity;
        private int detectSpanInMSecsOnWait;

        public PriorityManagerPara()
        {
            this.capacity = 0x7fffffff;
            this.actionTypeOnAddOverflow = CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow.Wait;
            this.detectSpanInMSecsOnWait = 10;
        }

        public PriorityManagerPara(int _capacity, CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow actionType)
        {
            this.capacity = 0x7fffffff;
            this.actionTypeOnAddOverflow = CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow.Wait;
            this.detectSpanInMSecsOnWait = 10;
            this.capacity = _capacity;
            this.actionTypeOnAddOverflow = actionType;
        }

        public PriorityManagerPara(int _capacity, CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow actionType, int _detectSpanInMSecsOnWait)
        {
            this.capacity = 0x7fffffff;
            this.actionTypeOnAddOverflow = CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow.Wait;
            this.detectSpanInMSecsOnWait = 10;
            this.capacity = _capacity;
            this.actionTypeOnAddOverflow = actionType;
            this.detectSpanInMSecsOnWait = _detectSpanInMSecsOnWait;
        }

        public CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow ActionTypeOnAddOverflow
        {
            get
            {
                return this.actionTypeOnAddOverflow;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public int DetectSpanInMSecsOnWait
        {
            get
            {
                return this.detectSpanInMSecsOnWait;
            }
            set
            {
                this.detectSpanInMSecsOnWait = (value <= 0) ? 1 : value;
            }
        }
    }
}

