namespace CJBasic.ObjectManagement.Managers
{
    using System;

    public enum ActionTypeOnAddOverflow
    {
        Wait,
        DiscardOldest,
        DiscardLatest,
        DiscardCurrent
    }
}

