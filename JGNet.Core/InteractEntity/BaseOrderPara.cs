using System;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class BaseOrderPara
    { 
        public string ColumnOrderby { get; set; }

        /// <summary>
        /// 是否升序
        /// </summary>
        public bool Ascend { get; set; }
    }
     
}