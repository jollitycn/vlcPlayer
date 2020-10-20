using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace WxPayAPI
{
    public class WxPayApi
    {
        /**
        *    
        * 查询订单
        * @param WxPayData inputObj 提交给查询订单API的参数
        * @param int timeOut 超时时间
        * @throws WxPayException
        * @return 成功时返回订单查询结果，其他抛异常
        */
        public static WxPayData OrderQuery(WxPayData inputObj, string appid, string mchid, string key, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/orderquery";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
            {
                throw new WxPayException("订单查询接口中，out_trade_no、transaction_id至少填一个！");
            }

            inputObj.SetValue("appid", appid);//公众账号ID
            inputObj.SetValue("mch_id", mchid);//商户号
            inputObj.SetValue("nonce_str", WxPayApi.GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign(key));//签名

            string xml = inputObj.ToXml();

            var start = DateTime.Now;

            Log.Debug("WxPayApi", "OrderQuery request : " + xml);
            string response = HttpService.Post(xml, url, false, timeOut, "", "");//调用HTTP通信接口提交数据
            Log.Debug("WxPayApi", "OrderQuery response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的数据转化为对象以返回
            WxPayData result = new WxPayData();
            result.FromXml(response, key);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }
        
        /**
        * 
        * 申请退款
        * @param WxPayData inputObj 提交给申请退款API的参数
        * @param int timeOut 超时时间
        * @throws WxPayException
        * @return 成功时返回接口调用结果，其他抛异常
        */
        public static WxPayData Refund(WxPayData inputObj, string MCHID, string appid, string key, string SSLCERT_PATH, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
            {
                throw new WxPayException("退款申请接口中，out_trade_no、transaction_id至少填一个！");
            }
            else if (!inputObj.IsSet("out_refund_no"))
            {
                throw new WxPayException("退款申请接口中，缺少必填参数out_refund_no！");
            }
            else if (!inputObj.IsSet("total_fee"))
            {
                throw new WxPayException("退款申请接口中，缺少必填参数total_fee！");
            }
            else if (!inputObj.IsSet("refund_fee"))
            {
                throw new WxPayException("退款申请接口中，缺少必填参数refund_fee！");
            }
            else if (!inputObj.IsSet("op_user_id"))
            {
                throw new WxPayException("退款申请接口中，缺少必填参数op_user_id！");
            }
            
            inputObj.SetValue("appid", appid);//公众账号ID
            inputObj.SetValue("mch_id", MCHID);//商户号
            inputObj.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign(key));//签名
            
            string xml = inputObj.ToXml();
            var start = DateTime.Now;

            Log.Debug("WxPayApi", "Refund request : " + xml);
            string response = HttpService.Post(xml, url, true, timeOut, SSLCERT_PATH, MCHID);//调用HTTP通信接口提交数据到API
            Log.Debug("WxPayApi", "Refund response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时

            //将xml格式的结果转换为对象以返回
            WxPayData result = new WxPayData();
            result.FromXml(response, key);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }
        
        /**
        * 
        * 统一下单
        * @param WxPaydata inputObj 提交给统一下单API的参数
        * @param int timeOut 超时时间
        * @throws WxPayException
        * @return 成功时返回，其他抛异常
        */
        public static WxPayData UnifiedOrder(WxPayData inputObj, string appid, string mchid, string key, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no"))
            {
                throw new WxPayException("缺少统一支付接口必填参数out_trade_no！");
            }
            else if (!inputObj.IsSet("body"))
            {
                throw new WxPayException("缺少统一支付接口必填参数body！");
            }
            else if (!inputObj.IsSet("total_fee"))
            {
                throw new WxPayException("缺少统一支付接口必填参数total_fee！");
            }
            else if (!inputObj.IsSet("trade_type"))
            {
                throw new WxPayException("缺少统一支付接口必填参数trade_type！");
            }

            //关联参数
            if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
            {
                throw new WxPayException("统一支付接口中，缺少必填参数openid！trade_type为JSAPI时，openid为必填参数！");
            }
            if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
            {
                throw new WxPayException("统一支付接口中，缺少必填参数product_id！trade_type为JSAPI时，product_id为必填参数！");
            }
            
            inputObj.SetValue("appid", appid);//公众账号ID
            inputObj.SetValue("mch_id", mchid);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串

            //签名
            inputObj.SetValue("sign", inputObj.MakeSign(key));
            string xml = inputObj.ToXml();

            var start = DateTime.Now;

            Log.Debug("WxPayApi", "UnfiedOrder request : " + xml);
            string response = HttpService.Post(xml, url, false, timeOut, "", "");
            Log.Debug("WxPayApi", "UnfiedOrder response : " + response);

            var end = DateTime.Now;
            int timeCost = (int)((end - start).TotalMilliseconds);

            WxPayData result = new WxPayData();
            result.FromXml(response, key);

            ReportCostTime(url, timeCost, result);//测速上报

            return result;
        }
        
        /**
	    * 
	    * 测速上报
	    * @param string interface_url 接口URL
	    * @param int timeCost 接口耗时
	    * @param WxPayData inputObj参数数组
	    */
        private static void ReportCostTime(string interface_url, int timeCost, WxPayData inputObj)
	    {
		    //如果不需要进行上报
		    if(WxPayConfig.REPORT_LEVENL == 0)
            {
			    return;
		    } 

		    //如果仅失败上报
		    if(WxPayConfig.REPORT_LEVENL == 1 && inputObj.IsSet("return_code") && inputObj.GetValue("return_code").ToString() == "SUCCESS" &&
			 inputObj.IsSet("result_code") && inputObj.GetValue("result_code").ToString() == "SUCCESS")
            {
		 	    return;
		    }
		 
		    //上报逻辑
		    WxPayData data = new WxPayData();
            data.SetValue("interface_url",interface_url);
		    data.SetValue("execute_time_",timeCost);
		    //返回状态码
		    if(inputObj.IsSet("return_code"))
            {
			    data.SetValue("return_code",inputObj.GetValue("return_code"));
		    }
		    //返回信息
            if(inputObj.IsSet("return_msg"))
            {
			    data.SetValue("return_msg",inputObj.GetValue("return_msg"));
		    }
		    //业务结果
            if(inputObj.IsSet("result_code"))
            {
			    data.SetValue("result_code",inputObj.GetValue("result_code"));
		    }
		    //错误代码
            if(inputObj.IsSet("err_code"))
            {
			    data.SetValue("err_code",inputObj.GetValue("err_code"));
		    }
		    //错误代码描述
            if(inputObj.IsSet("err_code_des"))
            {
			    data.SetValue("err_code_des",inputObj.GetValue("err_code_des"));
		    }
		    //商户订单号
            if(inputObj.IsSet("out_trade_no"))
            {
			    data.SetValue("out_trade_no",inputObj.GetValue("out_trade_no"));
		    }
		    //设备号
            if(inputObj.IsSet("device_info"))
            {
			    data.SetValue("device_info",inputObj.GetValue("device_info"));
		    }
		
		    try
            {
			    //Report(data);
		    }
            catch (WxPayException ex)
            {
			    //不做任何处理
		    }
	    }
        
        /**
        * 根据当前系统时间加随机序列来生成订单号
         * @return 订单号
        */
        public static string GenerateOutTradeNo(string MCHID)
        {
            var ran = new Random();
            return string.Format("{0}{1}{2}", MCHID, DateTime.Now.ToString("yyyyMMddHHmmss"), ran.Next(999));
        }

        /**
        * 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
         * @return 时间戳
        */
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /**
        * 生成随机串，随机串包含字母或数字
        * @return 随机串
        */
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}