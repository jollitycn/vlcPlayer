using JGNet.Core.Common;
using JGNet.Core.Dev.InteractEntity;
using JGNet.Core.InteractEntity;
using JGNet.Core.MyEnum;
using JGNet.Server.Const;
using System;
using System.Collections.Generic;

namespace JGNet.Server.Tools
{
    public static class ErrorMsgHelper
    {
        public static WebResponseObj<T> SetErrorInfo<T>(WebResponseObj<T> webResponseObj, string msg = ErrorMsg.Info)
        {
            webResponseObj.Status = (int)ResultStatus.Error;
            webResponseObj.ResponseCode = ResponseCode.Error;
            webResponseObj.Info = msg;
            return webResponseObj;
        }

        public static WebResponseObj<T> SetErrorInfo<T>(WebResponseObj<T> webResponseObj, Exception ee)
        {
            string msg = ErrorMsg.Info;
            if (ee is MyException)
            {
                msg = ee.Message;
            }
            webResponseObj.Status = (int)ResultStatus.Error;
            webResponseObj.ResponseCode = ResponseCode.Error;
            webResponseObj.Info = msg;
            return webResponseObj;
        }

        public static InteractResult SetErrorInfo(InteractResult interactResult, string msg = ErrorMsg.Info)
        {
            interactResult.ExeResult = ExeResult.Error;
            interactResult.ResponseCode = ResponseCode.Error;
            interactResult.Msg = msg;
            return interactResult;
        }

        public static InteractResult<T> SetErrorInfo<T>(InteractResult<T> interactResult, string msg = ErrorMsg.Info)
        {
            interactResult.ExeResult = ExeResult.Error;
            interactResult.ResponseCode = ResponseCode.Error;
            interactResult.Msg = msg;
            return interactResult;
        }

        public static InteractResult SetErrorInfo(InteractResult interactResult, Exception ee)
        {
            string msg = ErrorMsg.Info;
            if (ee is MyException)
            {
                msg = ee.Message;
            }
            interactResult.ExeResult = ExeResult.Error;
            interactResult.ResponseCode = ResponseCode.Error;
            interactResult.Msg = msg;
            return interactResult;
        }

        public static InteractResult<T> SetErrorInfo<T>(InteractResult<T> interactResult, Exception ee)
        {
            string msg = ErrorMsg.Info;
            if (ee is MyException)
            {
                msg = ee.Message;
            }
            interactResult.ExeResult = ExeResult.Error;
            interactResult.ResponseCode = ResponseCode.Error;
            interactResult.Msg = msg;
            return interactResult;
        }
    }

    public enum ResultStatus
    {
        Error = -1,

        Success
    }

    public static class ErrorMsg
    {
        public const string Info = "服务发生异常";
    }
}
