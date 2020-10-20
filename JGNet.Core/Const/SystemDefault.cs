using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Const
{
    public static class SystemDefault
    { 
        public const string ADMIN_USER_DEFAULT_NO_PERMISSION = "none";
        public const string DefaultAdmin = "admin";
        public const int DefaultAdminRole= 1;
        public const string DefaultAdminPassword = "123456";


        public const string DEFAULT_STRING_BREAKING = "\r\n";
        public const string Report_Summary = "_summary";

        public const string Report_Online = "_online";

        public const string onlineName = "线上商城";
        
        public static readonly DateTime DateTimeNull = new DateTime(2000, 1, 1);

        public const int ShopMonthTaskMoneyOfSale = 100000;

        public const int GuideMonthTaskMoneyOfSale = 10000;

        public const string WithoutID = "0";

        public const string WithoutName = "无";

        public const string SolutionName = "易联售";
        public const string BulkSupplier = "散货供应商";

        public const string Pwd = "888888";

        public const string ForeShiftStartTime = "08:00";

        public const string ForeShiftEndTime = "17:00";

        public const string NightShiftStartTime = "14:00";

        public const string NightShiftEndTime = "23:00";

        public const int AiDeployerPortCallBack = 9000;

        public const int AiDeployerPort4Service = 9001;

        public const int HeartbeatTime = 10;

        public const int HeartbeatTimeout = 30;

        public const string ErrorJson = "{\"Status\": -1, \"Info\": \"服务发生异常\", \"ResponseCode\": -1 }";

        public const string SuccessJson = "{\"Status\": 0, \"Info\": \"Success\", \"ResponseCode\": 0 }";

        public const char SPLIT_CHAR_COMMA = ',';
        public const string Comma = ",";

        public const string Semicolon = ";";

        public const int EmShopPageSize = 10;

        public const string Totals = "*";

        public const string JsonDateTimeFormat = "yyyy-MM-dd HH:mm";

        public const string Wx_Openid_Url = "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code";

        public const string Wx_AccessToken_Url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        public const int OnlineAutoID = 0;

        public const string DefaultSizeGroup = "Default";

        public const string SizeNames = "XS,S,M,L,XL,XL2,XL3,XL4,XL5,XL6,F";

        public const int MaxFilterList = 1000;

        public const int PhotoSize = 300;

        public const string TrialExpiredDateTip = "试用期限已到，请购买正式版本";

        public const string ExpiredDateTip = "账套已过期，请续费";

        public const string COSTUME_ID = "CostumeID";

        public const int MaxDBInsert = 10000;

        public const string DefaultRoleName = "注册人";
        
        public const string KuaiDi100Url2 = "http://poll.kuaidi100.com/poll/query.do?customer={0}&sign={1}&param={2}";//账号：tywl_kuaidi 密码:tywl_kuaidi

        public const string KuaiDI100Key = "BKivmdfG1998";

        public const string KuaiDI100Customer = "96E3CA21D46158CFCEAE6B64AE2CF049";

        public const string COSAPI_CGI_URL = "https://gz.file.myqcloud.com/files/v2/";
    }
}
