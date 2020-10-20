using JGNet.Core.Const;
using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Dev.InteractEntity
{
    [Serializable]
    public class WebResponseObj<T>
    {
        public int Status { get; set; }

        private string info = "Success";
        public string Info { get => this.info; set => this.info = value; }
        
        public T Data { get; set; }

        /// <summary>
        /// 响应编码，界面根据编码显示对应文字
        /// </summary>
        public ResponseCode ResponseCode { get; set; }
    }
}
