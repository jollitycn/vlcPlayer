using CCWin;
using JGNet.Core;
using JGNet.Core.Tools;
using JGNet.Common.Core.Util;
using CJBasic.Loggers;
using CJPlus.Rapid;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Reflection;
using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using JGNet.Common.Core;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using JGNet.Common.Entitys;
using JGNet.Core.RemotingEntity;
using JGNet.Core.Const;
using JGNet.Common.Components;
using JGNet.Core.Dev.InteractEntity;
using System.Drawing;
using JGNet.Core.InteractEntity;
using System.Data;
using System.IO;
using QCloud.CosApi.Api;
using QCloud.CosApi.Common;
using Newtonsoft.Json;

namespace JGNet.Common
{
    public class CommonGlobalUtil
    {

        public static BaseForm MainForm { get; set; }
        public static string GetArrayString(String[] arrs, char appendChar)
        {
            String result = string.Empty;
            if (arrs != null)
            {
                foreach (var item in arrs)
                {
                    result += item + appendChar;
                }
            }
            if (!String.IsNullOrEmpty(result))
            {
                result = result.Substring(0, result.LastIndexOf(appendChar));
            }
            return result;
        }

        /// <summary>
        /// 获取指定的类并返回这个CONTROL
        /// </summary>
        /// <param name="sourceCtrl"></param>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static Control FindBaseControl(Control sourceCtrl, params Type[] controls)
        {
            Control ctrl = sourceCtrl.Parent;
            if (ctrl != null)
            {
                bool getIt = false;
                foreach (var item in controls)
                {

                    if (item.IsAssignableFrom(ctrl.GetType()))
                    {
                        getIt = true;
                        break;
                    }
                }

                if (!getIt)
                {
                    ctrl = FindBaseControl(ctrl, controls);
                }
            }
            return ctrl;
        }

        public static List<ContextMenuStrip> GetContextMenuStrips(Control baseUserControl)
        {
            List<ContextMenuStrip> buttons = new List<ContextMenuStrip>();
            if (baseUserControl != null)
            {
                if (baseUserControl.ContextMenuStrip != null)
                {
                    buttons.Add(baseUserControl.ContextMenuStrip);
                }
                if (baseUserControl.Controls != null)
                {
                    foreach (var item in baseUserControl.Controls)
                    {
                        List<ContextMenuStrip> btns = GetContextMenuStrips(item as Control);
                        if (btns != null && btns.Count > 0)
                        {
                            buttons.AddRange(btns);
                        }

                    }
                    //buttons.Add();
                }
            }
            return buttons;
        }

        public static List<T> GetControls<T>(Control baseUserControl)
        {
            List<T> buttons = new List<T>();
            if (baseUserControl != null)
            {
                if (baseUserControl.Controls != null)
                {
                    foreach (var item in baseUserControl.Controls)
                    {
                        if (item is T)
                        {
                            buttons.Add((T)(Object)item);
                        }
                        else
                        {
                            List<T> btns = GetControls<T>(item as Control);
                            if (btns != null && btns.Count > 0)
                            {
                                buttons.AddRange(btns);
                            }
                        }
                    }
                }
                //buttons.Add();
            }
            return buttons;
        }

        /// <summary>
        /// 獲取控件對應的 BaseUserControl 或者 BaseForm
        /// </summary>
        /// <param name="control"></param>
        /// <param name="roolToEnd">是否循環到最後</param>
        /// <returns></returns>
        public static Control GetBase(Control control, bool roolToEnd)
        {
            if (control == null)
            {
                return null;
            }
            if (control is BaseUserControl || control is BaseForm)
            {
                if (roolToEnd)
                {
                    Control lastCtrl = control;
                    while (lastCtrl is BaseUserControl || lastCtrl is BaseForm)
                    {
                        Control findedCtrl = GetBase(lastCtrl.Parent, roolToEnd);
                        if (!(findedCtrl is BaseUserControl || findedCtrl is BaseForm))
                        {
                            break;
                        }
                        else
                        {
                            lastCtrl = findedCtrl;
                        }
                    }
                    return lastCtrl;

                    // Control ctrl = GetBase(control.Parent, roolToEnd);
                }
                else
                {
                    return control;
                }
            }
            else
            {
                return GetBase(control.Parent, roolToEnd);
            }
        }
        /// <summary>
        /// 解锁页面
        /// </summary>
        /// <param name="control"></param>
        public static void UnLockPage(Control control)
        {
            try
            {
                Control checkControl = control;
                if (checkControl is DataGridViewPagingSumCtrl)
                {
                    checkControl = GetBase(checkControl, true);
                }

                if (checkControl is BaseUserControl)
                {
                    BaseUserControl userControl = checkControl as BaseUserControl;

                    userControl.UnWaiting();
                    userControl.Cursor = Cursors.Default;
                    // userControl.UseWaitCursor = false;
                    //    CommonGlobalUtil.WriteLog("unwait:" + userControl?.GetType());
                }
                else if (checkControl is BaseForm)
                {
                    BaseForm form = null;
                    form = checkControl as BaseForm;
                    if (form != null)
                    {
                        form.UnWaiting();
                        form.UseWaitCursor = false;

                    }
                    //    CommonGlobalUtil.WriteLog("unwait:" + form?.GetType());
                }
            }
            catch (Exception ex) {
                CommonGlobalUtil.ShowError(ex);
            }

        }
        public static BarCode4Costume GetBarCode(string text)
        {
            InteractResult<BarCode4Costume> result = CommonGlobalCache.ServerProxy.ParsingBarCode(text);
            BarCode4Costume barCode4Costume = null;
            if (result != null)
            {
                switch (result.ExeResult)
                {
                    case ExeResult.Success:
                        if (result.Data != null)
                        {
                            barCode4Costume = result.Data;
                        }
                        break;
                    case ExeResult.Error:
                        GlobalMessageBox.Show(result.Msg);
                        break;
                    default:
                        break;
                }
            }
            return barCode4Costume;
        }

        /// <summary>
        /// 490 在收银界面点击会员充值，充值完成后回到收银界面，状态显示在加载
        /// 找不到findForm，当操作成功调用sucess事件后，tabpage被移除，对应用户控件找不到form了
        /// usercontrol 不能使用UseWaitCursor，而是用Cursor
        /// </summary>
        /// <param name="control"></param>
        /// <param name="isLoginForm"></param>
        /// <returns></returns>
        public static bool EngineUnconnectioned(Control control, Boolean isLoginForm = false, Boolean showError = true, Boolean cursorStatus = true)
        {
            Control checkControl = control;
            if (checkControl is DataGridViewPagingSumCtrl)
            {
                checkControl = GetBase(checkControl, true);
            }

            //control.Enabled = false;
            if (checkControl is BaseUserControl)
            {
                BaseUserControl userControl = checkControl as BaseUserControl;

                if (cursorStatus)
                {
                    userControl.Waiting();
                    userControl.Cursor = Cursors.WaitCursor;
                }
                //  CommonGlobalUtil.WriteLog("wait:" + userControl?.GetType());
            }
            else if (checkControl is BaseForm)
            {
                BaseForm form = null;
                form = checkControl as BaseForm;
                if (form != null)
                {
                    // form.
                    if (cursorStatus)
                    {
                        form.Waiting();
                        form.UseWaitCursor = true;
                    }
                }
                //  CommonGlobalUtil.WriteLog("wait:" + form?.GetType());
            }



            bool value = true;
            if (isLoginForm)
            {
                value = false;
            }
            else
            {

                if (CommonGlobalUtil.Engine.Connected)
                {
                    value = false;
                }
                else
                {
                    CommonGlobalUtil.WriteLog(new Exception("网络已断开！"));
                    if (showError)
                    {
                        GlobalMessageBox.Show("网络已断开！");
                    }
                }
            }
            return value;
        }

        public static bool ImportValidate(DataRow row, int columnCount)
        {
            bool unValidate = true;
            for (int i = 0; i < columnCount; i++)
            {
                String value = CommonGlobalUtil.ConvertToString(row[i]);
                if (!String.IsNullOrEmpty(value))
                {
                    //有值
                    unValidate = false;
                    break;
                }
            }
            return unValidate;
        }


        public static string GetSizeDisplayNames(SizeGroup sizeGroup, String sizeNames)
        {
            String displayNames = string.Empty;
            if (!String.IsNullOrEmpty(sizeNames))
            {
                String[] sizeNameArrs = sizeNames.Split(SystemDefault.SPLIT_CHAR_COMMA);
                if (sizeNameArrs != null)
                {
                    foreach (var sizeName in sizeNameArrs)
                    {
                        displayNames += CostumeStoreHelper.GetCostumeSizeName(sizeName, sizeGroup) + ",";
                    }

                }
            }
            if (!String.IsNullOrEmpty(displayNames))
            {
                displayNames = displayNames.Substring(0, displayNames.LastIndexOf(SystemDefault.Comma));
            }
            return displayNames;
        }

        public static decimal ConvertToDecimal(object v)
        {
            decimal value = 0;
            try
            {
                value = Convert.ToDecimal(v);
            }
            catch
            {
            }
            return value;
        }

        public static int ConvertToInt32(object v)
        {
            int value = 0;
            try
            {
                value = Convert.ToInt32(v);
            }
            catch
            {
            }
            return value;
        }

        public static String ConvertToString(object v)
        {
            String value = string.Empty;
            try
            {
                value = v.ToString().Trim();
            }
            catch
            {
            }
            return value;
        }

        public static short ConvertToInt16(object v)
        {
            short value = 0;
            try
            {
                value = Convert.ToInt16(v);
            }
            catch
            {
            }
            return value;
        }

        public static bool IsCostumeSizeColumn(DataGridViewColumn column)
        {
            bool isCostumeSizeColumn = false;
            List<Object> list = ReflectUtil.GetFields(typeof(CostumeSize));
            object obj = list.Find(t => t.ToString() == column.DataPropertyName);
            if (obj != null)
            {
                isCostumeSizeColumn = true;
            }
            return isCostumeSizeColumn;
        }

        public static void ChangeSizeGroup(DataGridView view, SizeGroup sizeGroup, bool changedColumnVisable = false)
        { //CostumeID
            List<String> displayNames;
            List<String> sizeNameList = CommonGlobalCache.GetShowSizeNames(view, out displayNames);
            ChangeCommonSizeGroup(view, sizeGroup, displayNames, sizeNameList, changedColumnVisable);
            ChangeAtmSizeGroup(view, sizeGroup, displayNames, sizeNameList, changedColumnVisable);
        }

        private static void ChangeAtmSizeGroup(DataGridView view, SizeGroup sizeGroup, List<String> displayNames, List<String> sizeNameList, bool changedColumnVisable = false)
        {


            int fromColumnIndex = -1;
            int toColumnIndex = -1;
            foreach (DataGridViewColumn item in view.Columns)
            {
                if (item.DataPropertyName.ToUpper() == CostumeSize.F + "ATM")
                {
                    fromColumnIndex = item.Index;
                }
                else if (item.DataPropertyName.ToUpper() == CostumeSize.XL6 + "ATM")
                {
                    toColumnIndex = item.Index;
                }
            }

            if (sizeGroup != null)
            {
                for (int i = 0; i < view.Columns.Count; i++)
                {
                    if (i >= fromColumnIndex && i <= toColumnIndex)
                    {
                        DataGridViewColumn column = view.Columns[i];
                        if (sizeNameList != null && sizeNameList.Count > 0)
                        {
                            if (changedColumnVisable)
                            {
                                column.Visible = false;
                            }
                            for (int j = 0; j < sizeNameList.Count; j++)
                            {
                                String sizeName = sizeNameList[j];
                                if (sizeName + "ATM".ToUpper() == column.DataPropertyName.ToUpper())
                                {
                                    if (changedColumnVisable)
                                    {
                                        column.Visible = true;
                                        column.HeaderText = displayNames[j];
                                    }
                                }

                            }
                        }
                        //String commonSizeName = column.DataPropertyName.Substring(0, column.DataPropertyName.IndexOf("Atm"));
                        //String value = CostumeStoreHelper.GetCostumeSizeName(commonSizeName, sizeGroup);
                        //column.HeaderText = value;
                    }
                }
            }
        }

        private static void ChangeCommonSizeGroup(DataGridView view, SizeGroup sizeGroup, List<String> displayNames, List<String> sizeNameList, bool changedColumnVisable = false)
        {

            int fromColumnIndex = -1;
            int toColumnIndex = -1;
            foreach (DataGridViewColumn item in view.Columns)
            {
                if (item.DataPropertyName == CostumeSize.F)
                {
                    fromColumnIndex = item.Index;
                }
                else if (item.DataPropertyName == CostumeSize.XL6)
                {
                    toColumnIndex = item.Index;
                }

            }



            if (sizeGroup != null)
            {
                for (int i = 0; i < view.Columns.Count; i++)
                {
                    if (i >= fromColumnIndex && i <= toColumnIndex)
                    {
                        DataGridViewColumn column = view.Columns[i];


                        if (sizeNameList != null && sizeNameList.Count > 0)
                        {
                            if (changedColumnVisable)
                            {
                                column.Visible = false;
                            }
                            for (int j = 0; j < sizeNameList.Count; j++)
                            {
                                String sizeName = sizeNameList[j];

                                if (sizeName.ToUpper() == column.DataPropertyName.ToUpper())
                                {
                                    if (changedColumnVisable)
                                    {
                                        //显示
                                        column.Visible = true;
                                        column.HeaderText = displayNames[j];

                                    }
                                }


                            }
                        }
                    }
                }
            }
        }

        public static bool GetOptionValueBoolean(String optionKey)
        {
            Option o = OptionConfiguration.GetOptionSetting(optionKey);
            if (o == null)
            {
                return true;
            }
            else
            {
                return Boolean.Parse(o.Value);
            }
        }
        /// <summary>
        /// 报表为零时是否显示
        /// </summary>
        /// <returns></returns>
        public static bool OptionIsReportShowZero()
        {
            Option o = OptionConfiguration.GetOptionSetting(OptionConfiguration.OPTION_CONFIGURATION_KEY_REPORT_SHOW_ZERO);
            if (o == null)
            {
                return true;
            }
            else
            {
                return Boolean.Parse(o.Value);
            }
        }

        public static bool OptionShowDiffInCheckStore()
        {
            Option o = OptionConfiguration.GetOptionSetting(OptionConfiguration.OPTION_CONFIGURATION_KEY_DIFFERENT_IN_CHECKSTORE);
            if (o == null)
            {
                return true;
            }
            else
            {
                return Boolean.Parse(o.Value);
            }
        }

        public static int GetExpiredRemainDays()
        {
            DateTime dateNow = DateTime.Now;
            DateTime now = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0);
            double days = DateTimeUtil.CompareDays(now, CommonGlobalCache.BusinessAccount.ExpiredDate);
            return Int32.Parse(Math.Round(days, 0, MidpointRounding.AwayFromZero).ToString());
        }

        public static String GetExpiredRemainDaysStr()
        {
            DateTime dateNow = DateTime.Now;
            DateTime now = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0);
            double days = DateTimeUtil.CompareDays(now, CommonGlobalCache.BusinessAccount.ExpiredDate);
            return "系统将于" + Math.Round(days, 0, MidpointRounding.AwayFromZero) + "天后到期，到期未缴费将自动停用，请及时缴费以免影响使用!";
        }


        /// <summary>
        /// 接近2个月提示，续费
        /// </summary>
        /// <returns></returns>
        public static bool CheckExpiredDate()
        {
            bool remainTimes = false;
            //if (!CommonGlobalCache.BusinessAccount.IsTrial)
            //{
            remainTimes = DateTime.Now.AddMonths(2) >= CommonGlobalCache.BusinessAccount.ExpiredDate;
            //  }
            return remainTimes;
        }

        public static bool OptionOutNotZeroStore()
        {
            Option o = OptionConfiguration.GetOptionSetting(OptionConfiguration.OPTION_CONFIGURATION_KEY_OUT_NOT_ZEROSTORE);
            if (o == null)
            {
                return true;
            }
            else
            {
                return Boolean.Parse(o.Value);
            }
        }

        public static string GetCostumeSizeName(string costumeID, string sizeName)
        {
            String displayName = String.Empty;
            Costume c = CommonGlobalCache.GetCostume(costumeID);
            displayName = CostumeStoreHelper.GetCostumeSizeName(sizeName, CommonGlobalCache.GetSizeGroup(c?.SizeGroupName));

            return displayName;
        }

        public static void SetCostumeSize(SkinComboBox skinComboBox_Size, Costume costume, SizeGroup sizeGroup = null, bool all = false, bool showAllList = true)
        {
            List<ListItem<String>> list = new List<ListItem<String>>();
            if (all)
            {
                list.Add(new ListItem<string>(CommonGlobalUtil.COMBOBOX_ALL, string.Empty));
            }
            if (showAllList)
            {
                if (costume != null)
                {
                    if (costume.SizeNameList != null && costume.SizeNameList.Count > 0)
                    {
                        sizeGroup = CommonGlobalCache.GetSizeGroup(costume.SizeGroupName);
                        foreach (var item in costume.SizeNameList)
                        {
                            String costumeSize = CostumeStoreHelper.GetCostumeSize(item, sizeGroup);
                            list.Add(new ListItem<string>(CostumeStoreHelper.GetCostumeSizeName(costumeSize, sizeGroup)
                            , costumeSize));
                        }
                    }
                }
                else
                {
                    String costumeSize = CostumeStoreHelper.GetCostumeSize(CostumeSize.F, sizeGroup);
                    list.Add(new ListItem<string>(CostumeStoreHelper.GetCostumeSizeName(costumeSize, sizeGroup)
                    , costumeSize));
                }
            }

            skinComboBox_Size.DisplayMember = "Key";
            skinComboBox_Size.ValueMember = "Value";
            skinComboBox_Size.DataSource = list;
        }

        public static string DEFAULT_COLOR_ID = "000";
        public static string DEFAULT_COLOR_NAME = "均色";
        public static string COMBOBOX_NULL = "无";
        public const string COMBOBOX_ALL = "所有";
        public const string COMBOBOX_HALF_YEAR = "近半年";
        public static readonly Font DEFAULT_FONT = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        public static string SystemDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\ELinkShop\\";
        public static string EmallDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\ELinkShop\\" + "emall\\";
        public static FileAgileLogger logger;
        /// <summary>
        /// 给充值规则按充值金额排序
        /// </summary>
        public static void RechargeDonateRuleSort(RechargeDonateRule rechargeDonate)
        {
            if (rechargeDonate != null)
            {
                rechargeDonate.Rules.Sort((x, y) => { return x.RechargeMoney.CompareTo(y.RechargeMoney); });
            }
        }

     

    public static void Initialize(bool isPos)
        {
            string logName = "ManageLog.txt";
            if (isPos)
            {
                logName = "PosLog.txt";
            }
            CommonGlobalUtil.logger = new CJBasic.Loggers.FileAgileLogger(CommonGlobalUtil.SystemDir + logName);
            logger.MaxLength4ChangeFile = 1024 * 1024;
        }

        public static void Initialize(String logName)
        {

            CommonGlobalUtil.logger = new CJBasic.Loggers.FileAgileLogger(CommonGlobalUtil.SystemDir + logName);
            logger.MaxLength4ChangeFile = 1024 * 1024;
        }

        public static bool GetBusinessAccountFromAPI(LoginAgileConfiguration config, out String response, string id)
        {
            Boolean isExist = false;
            HttpHandler httpHandler = new HttpHandler();

            String ipAddress = GetIPAddress(config);
            String url = "http://" + ipAddress + ":" + ConfigurationManager.AppSettings["PublishIPWebUrlPort"] + "/BusinessAccount/GetBusinessAccountInfo?id=" + id;
            response = httpHandler.Initialize().GetHttpResponse(url);
            if (String.IsNullOrEmpty(response) || response.Equals("账套不存在!") || response.Equals(SystemDefault.TrialExpiredDateTip) || response.Equals(SystemDefault.ExpiredDateTip))
            {
                if (String.IsNullOrEmpty(response))
                {
                    response = "获取账套信息失败！";
                }
                isExist = false;
            }
            else
            {
                isExist = true;
                config.BusinessAccount = (BusinessAccount)CJBasic.Serialization.SpringFox.ObjectXml(response);
            }
            //    httpHandler.Close();
            return isExist;

        }

        public static string GetColorFromGridView(List<string> colorList)
        {
            String colors = "";
            if (colorList != null)
            {
                foreach (var item in colorList)
                {
                    colors += item + ",";
                }
            }

            if (!String.IsNullOrEmpty(colors))
            {
                colors = colors.Remove(colors.LastIndexOf(","));
            }
            else
            {
                colors = "均色";
            }

            return colors;
        }

        public static string GetColorFromGridView(List<ListItem<string>> colorList)
        {
            String colors = "";
            if (colorList != null)
            {
                foreach (var item in colorList)
                {
                    colors += item.Key + ",";
                }
            }

            if (!String.IsNullOrEmpty(colors))
            {
                colors = colors.Remove(colors.LastIndexOf(","));
            }
            else
            {
                colors = "均色";
            }

            return colors;
        }

        //public static bool IsPfEnable()
        //{
        //    //return CommonGlobalCache.BusinessAccount.PfEnabled || CommonGlobalCache.BusinessAccount.OnlinePfEnabled;
        //    // return CommonGlobalCache.BusinessAccount.PfEnabled;
        //    return true;
        //}

        /// <summary>
        /// 根据域名获取IP地址
        /// </summary>
        private static string GetIPAddress(LoginAgileConfiguration config)
        {
            //return "localhost";
            String ipAddress = string.Empty;
            try
            {
                //可以直接域名使用，则获取到IP，没有的话使用原来的IP
                String webUrl = ConfigurationManager.AppSettings["PublishIPWebUrl"];
                IPAddress[] ips = System.Net.Dns.GetHostAddresses(webUrl);
                if (ips != null && ips.Length > 0)
                {
                    ipAddress = ips[0].ToString();
                    config.WebUrlIP = ipAddress;
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.WriteLog(ex);
            }
            if (String.IsNullOrEmpty(ipAddress))
            {
                if (config != null)
                {
                    ipAddress = config.WebUrlIP;
                }
            }
            return ipAddress;
        }

        /// <summary>
        /// 通知商务网站更新商品信息
        /// </summary>
        /// <param name="response"></param>
        /// <param name="isManage"></param>
        /// <returns></returns>
        public static String BusinessWebCostumePhotoChangeNotify(String costumeId)
        {
            String response = string.Empty;
            try
            {
                //HttpHandler httpHandler = new HttpHandler();
                //String url = CommonGlobalCache.BusinessAccount.BusinessWebUrl + "/API/DeleteCostumePhoto?businessAccountID=" + CommonGlobalCache.BusinessAccount.ID + "&costumeID=" + costumeId;
                //CommonGlobalUtil.WriteLog("访问商户网站：" + url);
                //response = httpHandler.Initialize().GetHttpResponse(url);
                //CommonGlobalUtil.WriteLog("访问商户网站成功！" + response);
                return response;
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.WriteLog(ex);
            }
            return response;
        }

        /// <summary>
        /// 获取自动更新服务器信息
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="isManage"></param>
        /// <returns></returns>
        public static AutoUpgradeInfo GetAutoUpgradeInfo(LoginAgileConfiguration loginInfo, int isManage)
        {
            AutoUpgradeInfo config = loginInfo.AutoUpgradeInfo;
            //获取本地临时文件的IP信息
            HttpHandler httpHandler = new HttpHandler();
            String ipAddress = GetIPAddress(loginInfo);
            String url = "http://" + ipAddress + ":" + ConfigurationManager.AppSettings["PublishIPWebUrlPort"] + "/BusinessAccount/GetAutoUpgradeInfo?isManager=" + isManage;
            WriteLog("获取自动更新服务器信息：" + url);
            String response = String.Empty;
            response = httpHandler.Initialize().GetHttpResponse(url);
            if (String.IsNullOrEmpty(response) || response.Equals("账套不存在!") || response.Equals(SystemDefault.TrialExpiredDateTip) || response.Equals(SystemDefault.ExpiredDateTip))
            {
                if (String.IsNullOrEmpty(response))
                {
                    response = "获取账套信息失败！";
                }
            }
            else
            {
                config = (AutoUpgradeInfo)CJBasic.Serialization.SpringFox.ObjectXml(response);
                loginInfo.AutoUpgradeInfo = config;
            }
            return config;
        }

        public static string AgileConfiguration(string str)
        {
            return SystemDir + str + ".dat";
        }

        public static void SetBrand(SkinComboBox skinComboBox_Brand, bool hideAll = false)
        {
            skinComboBox_Brand.DataSource = null;
            List<Brand> list = new List<Brand>();
            if (!hideAll)
            {
                list.Add(new Brand() { Name = CommonGlobalUtil.COMBOBOX_ALL, AutoID = -1 });
            }
            if (CommonGlobalCache.BrandList != null)
            {
                list.AddRange(CommonGlobalCache.BrandList.FindAll(t=>t.IsDisable==false));
            }
            skinComboBox_Brand.DisplayMember = "Name";
            skinComboBox_Brand.ValueMember = "AutoID";
            skinComboBox_Brand.DataSource = list;
        }

        public static bool Ping(string serverIP)
        {
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(serverIP, 120);//第一个参数为ip地址，第二个参数为ping的时间 
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        ///// <summary>
        ///// 设置大类小类
        ///// </summary>
        //public static  void SetBigClass(SkinComboBox skinComboBoxBigClass, Boolean hideAll = false)
        //{

        //    List<CostumeClass> classes = CommonGlobalCache.CostumeClassList;
        //    List<CostumeClass> list = new List<CostumeClass>();
        //    if (!hideAll)
        //    {
        //        list.Add(new CostumeClass() { BigClass = CommonGlobalUtil.COMBOBOX_ALL });
        //    }
        //    list.AddRange(classes);
        //    skinComboBoxBigClass.DisplayMember = "BigClass";
        //    skinComboBoxBigClass.ValueMember = "BigClass";
        //    skinComboBoxBigClass.DataSource = list;
        //}

        public static void SetCostumeColor(SkinComboBox skinComboBox_Color, Boolean hideAll = false, String[] colors = null, bool showAllList = true)
        {
            skinComboBox_Color.DataSource = null;
            List<CostumeColor> list = new List<CostumeColor>();
            if (!hideAll)
            {
                list.Add(new CostumeColor() { Name = CommonGlobalUtil.COMBOBOX_ALL, ID = null });
            }

            if (colors != null)
            {
                foreach (var item in colors)
                {
                    CostumeColor color = CommonGlobalCache.CostumeColorList.Find(t => t.Name == item);
                    if (color != null)
                    {
                        list.Add(color);
                    }
                }
            }
            else
            {
                if (showAllList)
                {
                    list.AddRange(CommonGlobalCache.CostumeColorList);
                }
            }

            skinComboBox_Color.DisplayMember = "Name";
            skinComboBox_Color.ValueMember = "ID";
            skinComboBox_Color.DataSource = list;
        }

        public static void SetAllocateReceivedOrderState(SkinComboBox skinComboBoxBoundState)
        {
            List<ListItem<AllocateOrderState>> boundStateList = new List<ListItem<AllocateOrderState>>();
            boundStateList.Add(new ListItem<AllocateOrderState>(EnumHelper.GetDescription(AllocateOrderState.All), AllocateOrderState.All));
            boundStateList.Add(new ListItem<AllocateOrderState>(EnumHelper.GetDescription(AllocateOrderState.Delivery), AllocateOrderState.Delivery));
            boundStateList.Add(new ListItem<AllocateOrderState>(EnumHelper.GetDescription(AllocateOrderState.Receipt), AllocateOrderState.Receipt));
            skinComboBoxBoundState.DisplayMember = "Key";
            skinComboBoxBoundState.ValueMember = "Value";
            skinComboBoxBoundState.DataSource = boundStateList;
            //   this.skinComboBox_State.SelectedIndex = 0;
        }
        public static void SetAllocateOrderReceiptState(SkinComboBox skinComboBox_State)
        {
            List<ListItem<ReceiptState>> stateList = new List<ListItem<ReceiptState>>();
            stateList.Add(new ListItem<ReceiptState>(EnumHelper.GetDescription(ReceiptState.All), ReceiptState.All));
            stateList.Add(new ListItem<ReceiptState>(EnumHelper.GetDescription(ReceiptState.WaitReceipt), ReceiptState.WaitReceipt));
            stateList.Add(new ListItem<ReceiptState>(EnumHelper.GetDescription(ReceiptState.Received), ReceiptState.Received)); 
            skinComboBox_State.DisplayMember = "Key";
            skinComboBox_State.ValueMember = "Value";
            skinComboBox_State.DataSource = stateList;
        }
        public static void SetAllocateOrderState(SkinComboBox skinComboBox_State)
        {
            List<ListItem<AllocateOrderState>> stateList = new List<ListItem<AllocateOrderState>>();
            stateList.Add(new ListItem<AllocateOrderState>(EnumHelper.GetDescription(AllocateOrderState.Normal), AllocateOrderState.Normal));
            stateList.Add(new ListItem<AllocateOrderState>(EnumHelper.GetDescription(AllocateOrderState.OverrideOrder), AllocateOrderState.OverrideOrder));
            stateList.Add(new ListItem<AllocateOrderState>(EnumHelper.GetDescription(AllocateOrderState.HangUp), AllocateOrderState.HangUp));
            stateList.Add(new ListItem<AllocateOrderState>(EnumHelper.GetDescription(AllocateOrderState.All), AllocateOrderState.All));
            skinComboBox_State.DisplayMember = "Key";
            skinComboBox_State.ValueMember = "Value";
            skinComboBox_State.DataSource = stateList;
        }


        public static void SetCostomerSaleType(SkinComboBox skinComboBox_State)
        {
                           
            List<ListItem<CostumeInvoicingDetailInType>> stateList = new List<ListItem<CostumeInvoicingDetailInType>>();
            stateList.Add(new ListItem<CostumeInvoicingDetailInType>(EnumHelper.GetDescription(CostumeInvoicingDetailInType.All), CostumeInvoicingDetailInType.All));
            stateList.Add(new ListItem<CostumeInvoicingDetailInType>(EnumHelper.GetDescription(CostumeInvoicingDetailInType.In), CostumeInvoicingDetailInType.In));
            stateList.Add(new ListItem<CostumeInvoicingDetailInType>(EnumHelper.GetDescription(CostumeInvoicingDetailInType.Return), CostumeInvoicingDetailInType.Return)); 
            skinComboBox_State.DisplayMember = "Key";
            skinComboBox_State.ValueMember = "Value";
            skinComboBox_State.DataSource = stateList;
        }
        public static void SetCostomerPfType(SkinComboBox skinComboBox_State)
        {

            List<ListItem<CostumeInvoicingDetailPfType>> stateList = new List<ListItem<CostumeInvoicingDetailPfType>>();
            stateList.Add(new ListItem<CostumeInvoicingDetailPfType>(EnumHelper.GetDescription(CostumeInvoicingDetailPfType.All), CostumeInvoicingDetailPfType.All));
            stateList.Add(new ListItem<CostumeInvoicingDetailPfType>(EnumHelper.GetDescription(CostumeInvoicingDetailPfType.Delivery), CostumeInvoicingDetailPfType.Delivery));
            stateList.Add(new ListItem<CostumeInvoicingDetailPfType>(EnumHelper.GetDescription(CostumeInvoicingDetailPfType.Return), CostumeInvoicingDetailPfType.Return));
            stateList.Add(new ListItem<CostumeInvoicingDetailPfType>(EnumHelper.GetDescription(CostumeInvoicingDetailPfType.Retail), CostumeInvoicingDetailPfType.Retail));
            skinComboBox_State.DisplayMember = "Key";
            skinComboBox_State.ValueMember = "Value";
            skinComboBox_State.DataSource = stateList;
        }
        public static void SetCostumeInvoicingDetailRetailTypeType(SkinComboBox skinComboBox_State)
        {
            List<ListItem<CostumeInvoicingDetailRetailType>> stateList = new List<ListItem<CostumeInvoicingDetailRetailType>>();
            stateList.Add(new ListItem<CostumeInvoicingDetailRetailType>(EnumHelper.GetDescription(CostumeInvoicingDetailRetailType.All), CostumeInvoicingDetailRetailType.All));
            stateList.Add(new ListItem<CostumeInvoicingDetailRetailType>(EnumHelper.GetDescription(CostumeInvoicingDetailRetailType.Retail), CostumeInvoicingDetailRetailType.Retail));
            stateList.Add(new ListItem<CostumeInvoicingDetailRetailType>(EnumHelper.GetDescription(CostumeInvoicingDetailRetailType.Return), CostumeInvoicingDetailRetailType.Return));
            skinComboBox_State.DisplayMember = "Key";
            skinComboBox_State.ValueMember = "Value";
            skinComboBox_State.DataSource = stateList;
        }

        public static void SetAllocateOrderType(SkinComboBox skinComboBox_State)
        {
            List<ListItem<AllocateOrderType>> typeList = new List<ListItem<AllocateOrderType>>();
            typeList.Add(new ListItem<AllocateOrderType>(EnumHelper.GetDescription(AllocateOrderType.All), AllocateOrderType.All));
            typeList.Add(new ListItem<AllocateOrderType>(EnumHelper.GetDescription(AllocateOrderType.In), AllocateOrderType.In));
            typeList.Add(new ListItem<AllocateOrderType>(EnumHelper.GetDescription(AllocateOrderType.Out), AllocateOrderType.Out));
            skinComboBox_State.DisplayMember = "Key";
            skinComboBox_State.ValueMember = "Value";
            skinComboBox_State.DataSource = typeList;
        }
        public static void SetCostumeManageType(SkinComboBox skinComboBox_State)
        {
            List<ListItem<EmCostumeInfoType>> typeList = new List<ListItem<EmCostumeInfoType>>();
            typeList.Add(new ListItem<EmCostumeInfoType>(EnumHelper.GetDescription(EmCostumeInfoType.All), EmCostumeInfoType.All));
            typeList.Add(new ListItem<EmCostumeInfoType>(EnumHelper.GetDescription(EmCostumeInfoType.Retail), EmCostumeInfoType.Retail));
            typeList.Add(new ListItem<EmCostumeInfoType>(EnumHelper.GetDescription(EmCostumeInfoType.Pf), EmCostumeInfoType.Pf));
            skinComboBox_State.DisplayMember = "Key";
            skinComboBox_State.ValueMember = "Value";
            skinComboBox_State.DataSource = typeList;
        }


        public static void SetShop(SkinComboBox skinComboBoxShopID, Boolean hideAll = false, Boolean excludeGeneralStoreShop = false, Boolean showOnline = false, Boolean emptyOnline = false,string shopId=null)
        {
            Boolean onlyValid = true;
            List<Shop> list = new List<Shop>();
            if (!hideAll)
            {
                list.Add(new Shop() { Name = CommonGlobalUtil.COMBOBOX_ALL, ID = null, Enabled = true });
            }
            list.AddRange(CommonGlobalCache.ShopList);
            if (excludeGeneralStoreShop)
            {
                list = list.FindAll(t => t.IsGeneralStore == false);
            }
            if (shopId != null)
            {
                list = list.FindAll(t => t.ID != shopId);
            }
            //else
            //{
            //    //if (CommonGlobalCache.ShopList != null)
            //    //{
            //    //    list?.AddRange(CommonGlobalCache.ShopList);
            //    //}
            //}


            if (showOnline)
            {

                if (!emptyOnline)
                {
                    list.Add(new Shop() { Name = SystemDefault.onlineName, ID = SystemDefault.Report_Online, Enabled = true });
                }
                else
                {
                    list.Add(new Shop() { Name = SystemDefault.onlineName, ID = string.Empty, Enabled = true });
                }
            }

            if (onlyValid)
            {
                list = list?.FindAll(t => t.Enabled);
            }

            skinComboBoxShopID.DisplayMember = "Name";
            skinComboBoxShopID.ValueMember = "ID";
            skinComboBoxShopID.DataSource = list;
        }

        public static void SetSupplier(SkinComboBox skinComboBox_Supplier, Boolean hideAll = false, bool isEnableList = false)
        {
            List<Supplier> list = new List<Supplier>();
            if (!hideAll)
            {
                list.Add(new Supplier() { Name = CommonGlobalUtil.COMBOBOX_ALL, ID = null,Enabled=true });
            }
            if (isEnableList)
            {
                if (CommonGlobalCache.EnabledSupplierList != null) { 
                list.AddRange(CommonGlobalCache.EnabledSupplierList);
                }
            }
            else
            {
                if (CommonGlobalCache.SupplierList != null)
                {
                    list.AddRange(CommonGlobalCache.SupplierList);
                }
            }
            skinComboBox_Supplier.DataSource = null;
            skinComboBox_Supplier.DisplayMember = "Name";
            skinComboBox_Supplier.ValueMember = "ID";
            skinComboBox_Supplier.DataSource = list;
        }

        public static void SetTime(SkinComboBox skinComboBox)
        {
            List<ListItem<QuickDateSelectorEnum>> list = new List<ListItem<QuickDateSelectorEnum>>();
            list.Add(new ListItem<QuickDateSelectorEnum>(EnumHelper.GetDescription(QuickDateSelectorEnum.TODAY), QuickDateSelectorEnum.TODAY));
            list.Add(new ListItem<QuickDateSelectorEnum>(EnumHelper.GetDescription(QuickDateSelectorEnum.YESTODAY), QuickDateSelectorEnum.YESTODAY));
            list.Add(new ListItem<QuickDateSelectorEnum>(EnumHelper.GetDescription(QuickDateSelectorEnum.THISWEEK), QuickDateSelectorEnum.THISWEEK));
            list.Add(new ListItem<QuickDateSelectorEnum>(EnumHelper.GetDescription(QuickDateSelectorEnum.LASTWEEK), QuickDateSelectorEnum.LASTWEEK));
            list.Add(new ListItem<QuickDateSelectorEnum>(EnumHelper.GetDescription(QuickDateSelectorEnum.THISMONTH), QuickDateSelectorEnum.THISMONTH));
            list.Add(new ListItem<QuickDateSelectorEnum>(EnumHelper.GetDescription(QuickDateSelectorEnum.LASTMONTH), QuickDateSelectorEnum.LASTMONTH));
            list.Add(new ListItem<QuickDateSelectorEnum>(EnumHelper.GetDescription(QuickDateSelectorEnum.THISYEAR), QuickDateSelectorEnum.THISYEAR));
            list.Add(new ListItem<QuickDateSelectorEnum>(EnumHelper.GetDescription(QuickDateSelectorEnum.LASTYEAR), QuickDateSelectorEnum.LASTYEAR));
            list.Add(new ListItem<QuickDateSelectorEnum>(EnumHelper.GetDescription(QuickDateSelectorEnum.ALL), QuickDateSelectorEnum.ALL));
            skinComboBox.DisplayMember = "Key";
            skinComboBox.ValueMember = "Value";
            skinComboBox.DataSource = list;
        }






        //public static String CheckBarCode(SkinTextBox textBox,string costumeID)
        //{ //条形码，先根据条形码获取款号
        //  //  bool isBarCode = false;
        //    String barCode = string.Empty;
        //    List<BarCode> barCodes = CommonGlobalCache.BarCodeList?.FindAll(t => t.BarCodeValue.ToUpper().Equals(costumeID.ToUpper()));

        //    //，条形码为一条，找到这个款号
        //    if (barCodes != null && barCodes.Count == 1)
        //    {
        //        costumeID = barCodes[0].CostumeID;
        //        textBox.SkinTxt.Text = barCodes[0].BarCodeValue;
        //  //      isBarCode = true;
        //    }

        //    return barCode;
        //}

        public static void DateTime_GetTodayAndAfterAMonth(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            //dateTimePicker_Start.Initialize();
            //dateTimePicker_End.Initialize();
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.GetTodayAndAfterAMonth(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }



        public static void DateTime_Yestoday(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.Yestoday(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }

        public static void DateTime_Today(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.Today(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }

        public static void DateTime_ThisMonth(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.ThisMonth(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }



        public static void DateTime_All(DateTimePicker startDateTimePicker, DateTimePicker endDateTimePicker)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.All(out startDate, out endDate);
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
        }

        public static void DateTime_ThisWeek(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.ThisWeek(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }


        public static void DateTime_LastYear(DateTimePicker dateTimePicker_Start, DateTimePicker dateTimePicker_End)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.LastYear(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }



        internal static void DateTime_LastWeek(DateTimePicker startDateTimePicker, DateTimePicker endDateTimePicker)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.LastWeek(out startDate, out endDate);
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
        }

        internal static void DateTime_LastMonth(DateTimePicker startDateTimePicker, DateTimePicker endDateTimePicker)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.LastMonth(out startDate, out endDate);
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
        }

        public static void DateTime_ThisYear(DateTimePicker startDateTimePicker, DateTimePicker endDateTimePicker)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.ThisYear(out startDate, out endDate);
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
        }

        public static void DateTime_ThisYearTillToday(DateTimePicker startDateTimePicker, DateTimePicker endDateTimePicker)
        {
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.ThisYearTillToday(out startDate, out endDate);
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
        }


        public static void DateTime_SetStartEndForMonth(YearMonthPicker dateTimePicker_Start, YearMonthPicker dateTimePicker_End)
        {
            //dateTimePicker_Start.Initialize();
            //dateTimePicker_End.Initialize();
            DateTime startDate = default(DateTime);
            DateTime endDate = default(DateTime);
            JGNet.Core.Tools.TimeHelper.SetStartEndForMonth(out startDate, out endDate);
            dateTimePicker_Start.Value = startDate;
            dateTimePicker_End.Value = endDate;
        }


        /// <summary>
        /// 检查字段是否是库存字段
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        /// <returns></returns>
        public static bool NotStoreColumnIndex(int columnIndex, int fromIndex, int toIndex)
        {
            return columnIndex < fromIndex || columnIndex > toIndex;
        }


        //public static void SetSmallClass(SkinComboBox skinComboBox_SmallClass,Boolean hideAll = false)
        //{
        //    skinComboBox_SmallClass.DataSource = null;
        //    List<ListItem<String>> list = new List<ListItem<String>>();
        //    if (!hideAll) { 
        //    list.Add(new ListItem<String>(CommonGlobalUtil.COMBOBOX_ALL, null));
        //    }
        //    skinComboBox_SmallClass.DisplayMember = "Key";
        //    skinComboBox_SmallClass.ValueMember = "Value";
        //    if (list != null)
        //    {
        //        skinComboBox_SmallClass.DataSource = list;
        //    }
        //}

        public static void SetParameterConfig(SkinComboBox skinComboBox_Season, String parameterConfigKey)
        {
            skinComboBox_Season.DataSource = null;
            skinComboBox_Season.DisplayMember = "Key";
            skinComboBox_Season.ValueMember = "Value";
            List<ListItem<String>> list = CommonGlobalUtil.ParameterConfigList(CommonGlobalCache.GetParameterConfig(parameterConfigKey));
            if (list != null)
            {
                skinComboBox_Season.DataSource = list;
            }
        }


        public static void SetYear(SkinComboBox skinComboBox_Year, Boolean hideAll = false)
        {
            List<ListItem<int>> list = new List<ListItem<int>>();
            if (!hideAll)
            {
                list.Add(new ListItem<int>(CommonGlobalUtil.COMBOBOX_ALL, -1));
            }
            List<int> years = YearHelper.GetYearList(DateTime.Now);
            foreach (int item in years)
            {
                list.Add(new ListItem<int>(item.ToString(), item));
            }

            skinComboBox_Year.DisplayMember = "Key";
            skinComboBox_Year.ValueMember = "Value";
            skinComboBox_Year.DataSource = list;
        }

        public static IAgileLogger Logger
        {
            get
            {
                return CommonGlobalUtil.logger;
            }
        }

        public static IRapidPassiveEngine Engine { get; set; }


        /// <summary>
        /// 获取源单据中的部分明细（包括发货店，发货店操作人，收货店，收货店操作人）
        /// </summary>
        /// <param name="sourceOrderID"></param>
        /// <returns></returns>
        public static SourceOrderPartialDetail GetSourceOrderPartialDetail(string sourceOrderID)
        {
            string firstChar = sourceOrderID[0].ToString();
            SourceOrderPartialDetail sourceOrderPartialDetail = new SourceOrderPartialDetail();
            switch (firstChar)
            {
                case OrderPrefix.AllocateOrder:
                    AllocateOrder allocateOrder = CommonGlobalCache.ServerProxy.GetAllocateOrder(sourceOrderID);
                    if (allocateOrder == null)
                    {
                        return null;
                    }
                    sourceOrderPartialDetail.SourceShopID = allocateOrder.SourceShopID;
                    sourceOrderPartialDetail.DestShopID = allocateOrder.DestShopID;
                    sourceOrderPartialDetail.SourceOperatorID = allocateOrder.SourceUserID;
                    sourceOrderPartialDetail.DestOperatorID = allocateOrder.DestUserID;
                    // sourceOrderPartialDetail.InboundCount=allocateOrder.
                    break;
                case OrderPrefix.ReplenishOrder:
                    ReplenishOrder replenishOrder = CommonGlobalCache.ServerProxy.GetReplenishOrder(sourceOrderID);
                    if (replenishOrder == null)
                    {
                        return null;
                    }
                    sourceOrderPartialDetail.DestShopID = replenishOrder.ShopID;
                    sourceOrderPartialDetail.SourceOperatorID = replenishOrder.RequestGuideID;
                    OutboundOrder outboundOrder = CommonGlobalCache.ServerProxy.GetOutboundOrder(replenishOrder.AllocateOrderID);
                    if (outboundOrder == null)
                    {
                        return null;
                    }
                    sourceOrderPartialDetail.SourceShopID = outboundOrder.ShopID;
                    sourceOrderPartialDetail.DestOperatorID = outboundOrder.OperatorUserID;
                    break;
                case OrderPrefix.PurchaseOrder:
                    PurchaseOrder purchaseOrder = CommonGlobalCache.ServerProxy.GetOnePurchaseOrder(sourceOrderID);
                    if (purchaseOrder == null)
                    {
                        return null;
                    }
                    sourceOrderPartialDetail.SourceShopID = purchaseOrder.SupplierID;
                    sourceOrderPartialDetail.SourceOperatorID = string.Empty;
                    sourceOrderPartialDetail.DestShopID = purchaseOrder.DestShopID;
                    sourceOrderPartialDetail.DestOperatorID = purchaseOrder.AdminUserID;

                    break;

                case OrderPrefix.ReturnOrder:
                    PurchaseOrder refundOrder = CommonGlobalCache.ServerProxy.GetOnePurchaseOrder(sourceOrderID);
                    if (refundOrder == null)
                    {
                        return null;
                    }
                    sourceOrderPartialDetail.SourceShopID = refundOrder.DestShopID;
                    sourceOrderPartialDetail.SourceOperatorID = refundOrder.AdminUserID;
                    sourceOrderPartialDetail.DestShopID = refundOrder.SupplierID;
                    sourceOrderPartialDetail.DestOperatorID = string.Empty;
                    break;

                case OrderPrefix.ScrapOrder:
                    ScrapOrder scrapOrder = CommonGlobalCache.ServerProxy.GetOneScrapOrder(sourceOrderID);
                    if (scrapOrder == null)
                    {
                        return null;
                    }
                    sourceOrderPartialDetail.SourceShopID = scrapOrder.ShopID;
                    sourceOrderPartialDetail.SourceOperatorID = scrapOrder.OperatorUserID;
                    sourceOrderPartialDetail.DestShopID = string.Empty;
                    sourceOrderPartialDetail.DestOperatorID = string.Empty;
                    break;
            }
            return sourceOrderPartialDetail;

        }

        /// <summary>
        /// 判断是否是管理员账号
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool IsAdminUser(string userID)
        {
            return CommonGlobalCache.AdminUserList.Exists(t => t.ID == userID);
        }

        public static List<ListItem<String>> ParameterConfigList(List<ListItem<String>> listItems)
        {
            List<ListItem<String>> list = new List<ListItem<String>>();
            list.Add(new ListItem<String>(CommonGlobalUtil.COMBOBOX_ALL, null));
            list.AddRange(listItems);
            return list;
        }

        public static string SalesPromotionRule(SalesPromotion sp, decimal totalMoneyReceived, int totalCount)
        {
            IPromotionRule rule = null;
            if (sp != null)
            {

                foreach (var item in sp.Rules)
                {
                    if (sp.PromotionType == (byte)PromotionTypeEnum.Discount)
                    {
                        DiscountPromotionRule dis = (DiscountPromotionRule)item;
                        //找到最匹配的值
                        if (dis.HitBuyCout <= totalCount)
                        {
                            rule = dis;
                        }
                        else { break; }
                    }
                    else if (sp.PromotionType == (byte)PromotionTypeEnum.MJ)
                    {
                        MJPromotionRule mj = (MJPromotionRule)item;
                        //找到最匹配的值
                        if (mj.HitMoney <= totalMoneyReceived)
                        {
                            rule = mj;
                        }
                        else { break; }
                    }

                }
            }
            return ValidateUtil.CheckEmptyValue(rule);
        }


        /// <summary>
        /// 检查商品款号是否存在
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        public static bool CostumeExist(string costumeID)
        {
            return CommonGlobalCache.CostumeList.Exists(t => t.ID.ToLower() == costumeID?.ToLower());
        }

        public static String OrderType(String orderID)
        {
            String value = "";
            if (string.IsNullOrEmpty(orderID))
            {
                return value;
            }
            String orderPrefix = orderID[0].ToString();
            switch (orderPrefix)
            {
                case OrderPrefix.AllocateOrder:
                    value = "调拨";
                    break;
                case OrderPrefix.CheckStoreOrder:
                    value = "盘点";
                    break;
                case OrderPrefix.InboundOrder:
                    value = "入库";
                    break;
                case OrderPrefix.OutboundOrder:
                    value = "出库";
                    break;
                case OrderPrefix.PurchaseOrder:
                    value = "采购进货";
                    break;
                case OrderPrefix.ReturnOrder:
                    value = "采购退货";
                    break;
                case OrderPrefix.ReplenishOrder:
                    value = "补货申请";
                    break;
                default:
                    value = "未确认类型";
                    break;
            }
            return value;
        }


        public static String[] GetStringSplit(String str, char spliter)
        {
            string[] values = null;
            if (!String.IsNullOrEmpty(str))
            {
                values = str.Split(spliter);
            }

            return values;
        }

        public static String GetValueStringFromListItem(List<ListItem<String>> listItems)
        {
            String value = "";
            foreach (var item in listItems)
            {
                value += item.Value + ",";

            }
            if (!String.IsNullOrEmpty(value)) { value = value.Remove(value.LastIndexOf(",")); }
            return value;
        }


        /// <summary>
        /// 记录异常日志
        /// </summary>
        /// <param name="ee"></param>
        public static void WriteLog(Exception ee)
        {
            try
            {

                if (CommonGlobalUtil.logger == null) {
                    Initialize("Common.log");
                }
                //StackTrace trace = new StackTrace();
                //StackFrame frame = trace.GetFrame(1);//1代表上级，2代表上上级，以此类推  
                //MethodBase method = frame.GetMethod();
                CommonGlobalUtil.logger.Log(ee, string.Empty, ErrorLevel.Standard);
            }
            catch { }
        }
        public static void WriteLog(String ee)
        {
            try
            {
                StackTrace trace = new StackTrace();
                StackFrame frame = trace.GetFrame(1);//1代表上级，2代表上上级，以此类推  
                MethodBase method = frame.GetMethod();
                CommonGlobalUtil.logger.Log("info", ee, method.DeclaringType.FullName + "." + method.Name, ErrorLevel.Standard);
            }
            catch { }
        }


        public static void Debug(String message)
        {
            try
            {
                StackTrace trace = new StackTrace();
                StackFrame frame = trace.GetFrame(1);//1代表上级，2代表上上级，以此类推  
                MethodBase method = frame.GetMethod();
                CommonGlobalUtil.logger.Log("Debug", message, method.DeclaringType.FullName + "." + method.Name, ErrorLevel.Standard);
            }
            catch { }
        }

        public static void ShowError(Exception ee, String message
       )
        {
            try
            {
                //StackTrace trace = new StackTrace();
                //StackFrame frame = trace.GetFrame(1);//1代表上级，2代表上上级，以此类推  
                //MethodBase method = frame.GetMethod();
                CommonGlobalUtil.logger.Log(ee, string.Empty, ErrorLevel.Standard);
                GlobalMessageBox.Show(message);
            }
            catch { }
        }

        public static void ShowError(String message, bool showMessage = true
          )
        {
            try
            {
                StackTrace trace = new StackTrace();
                StackFrame frame = trace.GetFrame(1);//1代表上级，2代表上上级，以此类推  
                MethodBase method = frame.GetMethod();
                CommonGlobalUtil.logger.Log("Error", message, method.DeclaringType.FullName + "." + method.Name, ErrorLevel.Standard);

                if (showMessage)
                {
                    GlobalMessageBox.Show(message);

                }
            }
            catch { }

        }

        public static void ShowError(Exception ex, bool showMessage = true)
        {
            try
            {
                //StackTrace trace = new StackTrace();
                //StackFrame frame = trace.GetFrame(1);//1代表上级，2代表上上级，以此类推  
                //MethodBase method = frame.GetMethod();
                CommonGlobalUtil.logger.Log(ex,string.Empty, ErrorLevel.Standard);
                if (showMessage)
                {
                    if (ex is TimeoutException)
                    {
                        GlobalMessageBox.Show("操作超时！");
                    }
                    if (ex is IOException)
                    {
                        if (ex.Message.Contains("because it is being used by another process.") || ex.Message.Contains("正由另一进程使用，因此该进程无法访问该文件"))
                        {
                            GlobalMessageBox.Show("导入文件已被打开，请关闭后再重新导入！");
                        }
                        else
                        {
                            GlobalMessageBox.Show(ex.Message);
                        }
                    }
                    else if (ex.Message.Equals("Network connection is disconnected!"))
                    {
                        GlobalMessageBox.Show("网络已断开。");
                    }
                    else if (ex.Message.Contains("Deserializing"))
                    {
                        GlobalMessageBox.Show("请更新最新版本！");
                    }
                    else if (ex.Message.Contains("正由另一个进程使用"))
                    {
                        GlobalMessageBox.Show("系统错误！" + ex.Message);
                    }
                    else if (ex is NoPermissonException)
                    {
                        GlobalMessageBox.Show(ex.Message);
                    }
                    else if (ex is TimeoutException)
                    {
                        GlobalMessageBox.Show("请求超时,确定网络正常,稍后再试!");
                    }
                    else
                    {
                        GlobalMessageBox.Show("系统错误！" + ex);
                    }
                }
            }
            catch
            {
            }
        }

        public static string GetPfAccountTypeName(int feeType)
        {
            PfAccountType type = (PfAccountType)feeType;
            return EnumHelper.GetDescription(type);
        }

        public static string GetAccountTypeName(int feeType)
        {
            AccountType type = (AccountType)feeType;
            return EnumHelper.GetDescription(type);
        }

        public static string GetFeeTypeName(int feeType)
        {
            CashRecordFeeType type = (CashRecordFeeType)feeType;
            return EnumHelper.GetDescription(type);
        }

        public static CosCloud VedioCosCloud;
        public static EmCostumePhoto UploadPhotoToCos(PhotoData para, string customerID)
        {
            InteractResult<CosCloudSignature> Signatureresult = CommonGlobalCache.ServerProxy.GetCosCloudSignature();
            if (Signatureresult.ExeResult == ExeResult.Success)
            {
                CosCloudSignature cosCloudSignature = Signatureresult.Data;

                VedioCosCloud = new CosCloud(cosCloudSignature.AppID, cosCloudSignature.Signature, 120);


                para.Name = JGNet.Core.ImageHelper.GetNewJpgName(customerID);
                // CosCloud cos = new CosCloud(cosLoginInfo.AppID, cosLoginInfo.SecretId, cosLoginInfo.SecretKey);
                Dictionary<string, string> uploadParasDic = new Dictionary<string, string>();
                uploadParasDic.Add(CosParameters.PARA_BIZ_ATTR, "");
                uploadParasDic.Add(CosParameters.PARA_INSERT_ONLY, "0");
                string result = VedioCosCloud.UploadFile2(cosCloudSignature.BucketName, string.Format("/{0}/{1}", CommonGlobalCache.BusinessAccount.ID, para.Name),
                    para.Name, para.Datas, uploadParasDic);
                // JObject jObject = (JObject)JsonConvert.DeserializeObject(result);
                ResultJson ResultJ = (ResultJson)JavaScriptConvert.DeserializeObject(result, typeof(ResultJson));
                if (ResultJ.code.ToString() == "0")
                {
                    Data dInfo = ResultJ.data;
                    string source_url = dInfo.source_url.ToString();
                    EmCostumePhoto CurCostmePhotoVideo = new EmCostumePhoto();

                    CurCostmePhotoVideo.LinkAddress = dInfo.source_url;
                    CurCostmePhotoVideo.IsVideo = false;
                    CurCostmePhotoVideo.PhotoName = para.Name;
                    CurCostmePhotoVideo.CostumeID = para.EmCostumePhoto.CostumeID;
                    CurCostmePhotoVideo.DisplayIndex = para.EmCostumePhoto.DisplayIndex;

                    return CurCostmePhotoVideo;
                    //para.LinkAddress = source_url;
                    //???  this.dbManager.DBEmPosterImageService.Insert(para.EmPosterImage);
                }
                else
                {
                    throw new Exception(string.Format("上传【{0}】图片发生错误-【{1}】", para.Name, result));
                }
            }
            return new EmCostumePhoto();
        }

        public static void SetTemplates(SkinComboBox skinComboBoxTemplate)
        {
            List<EmCarriageCostTemplate> list = CommonGlobalCache.ServerProxy.GetValidCarriageCostTemplates();

            skinComboBoxTemplate.DisplayMember = "Name";
            skinComboBoxTemplate.ValueMember = "AutoID";
            skinComboBoxTemplate.DataSource = list;
        }
        public static void SetCommissionTemplate(SkinComboBox skinComboBoxCommTemp,int DefaultCommissionTemplate)
        {
            InteractResult<List<CommissionTemplate>> interResult = CommonGlobalCache.ServerProxy.GetCommissionTemplates();
            if (interResult.Data.Count > 0)
            {
                foreach (CommissionTemplate commtemplate in interResult.Data)
                {
                    if (commtemplate.IsDefault == true)
                    {
                        DefaultCommissionTemplate = commtemplate.AutoID;
                    }
                }

            }

            List<CommissionTemplate> List = new List<CommissionTemplate>();
            List.Add(new CommissionTemplate() { Name = "无", AutoID = 0, });
            List.AddRange(interResult.Data);

            skinComboBoxCommTemp.DisplayMember = "Name";
            skinComboBoxCommTemp.ValueMember = "AutoID";
            skinComboBoxCommTemp.DataSource = List;
        }
        
    }
}
