using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CJBasic.Widget;
using CJBasic;
using CJBasic.Loggers;
using JGNet.Common.Core;
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Core.InteractEntity;
using JGNet.Common;
using JGNet.Core.Tools;
using JieXi.Common;
using JGNet.Common.Core.Util;
using System.IO;

namespace JGNet.Common
{
    public partial class MemberManageCtrl : BaseModifyUserControl
    {


        private MemberListPagePara pagePara;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        public event CJBasic.Action<Member, BaseUserControl> RechargeRecordClick;
        public event CJBasic.Action<Member, BaseUserControl> MemberGiftTicketClick;

        public event CJBasic.Action<Member, BaseUserControl> RechargeClick;
        public event CJBasic.Action<Member, BaseUserControl> UpdateMemberClick;
        public event Action<BaseUserControl> SendGiftTicketClick;
        public event CJBasic.Action<RetailListPagePara, BaseUserControl,bool> ConsumeHistoryClick;


        public MemberManageCtrl()
        {
            InitializeComponent();

            skinTextBox_ID.SkinTxt.KeyDown += SkinTxt_KeyDown;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, this.BaseButton_Search_Click, new String[] { currentIntegrationDataGridViewTextBoxColumn1.DataPropertyName, balanceDataGridViewTextBoxColumn1.DataPropertyName });
            dataGridViewPagingSumCtrl.Initialize();



            SetDays();
            SetUnconsumedDays();

            skinComboBoxShopID.Initialize(false, false, true); 
           
            //if (IsPos)
            //{

            //        skinCheckBox_showCurrentShopOnly.Visible = false;
            //        skinComboBoxShopID.Enabled = false;
            //        skinComboBoxShopID.SelectedValue = CommonGlobalCache.CurrentShopID;

            //}
            //else
            //{
            //    skinCheckBox_showCurrentShopOnly.Visible = false;
            //}


            // skinCheckBox_showCurrentShopOnly.Checked = IsPos;


            //baseButtonExport.Visible = !IsPos;
            //baseButtonImport.Visible = !IsPos;
            //downTemplateButton1.Visible = !IsPos;
            // baseButtonImport.Visible =false;

            MenuPermission = RolePermissionMenuEnum.会员管理;
        }

        private void SetDays()
        {

            List<ListItem<TimeRange>> list = new List<ListItem<TimeRange>>();

            list.Add(new ListItem<TimeRange>(EnumHelper.GetDescription(TimeRange.All), TimeRange.All));
            list.Add(new ListItem<TimeRange>(EnumHelper.GetDescription(TimeRange.Today), TimeRange.Today));
            list.Add(new ListItem<TimeRange>(EnumHelper.GetDescription(TimeRange.ThisWeek), TimeRange.ThisWeek));
            list.Add(new ListItem<TimeRange>(EnumHelper.GetDescription(TimeRange.ThisMonth), TimeRange.ThisMonth));
            this.skinComboBoxBigClass.DisplayMember = "Key";
            this.skinComboBoxBigClass.ValueMember = "Value";
            this.skinComboBoxBigClass.DataSource = list;
        }

        private void SetUnconsumedDays()
        {

            List<ListItem<int>> list = new List<ListItem<int>>();
            list.Add(new ListItem<int>("所有", -1));
            list.Add(new ListItem<int>("从未消费", -2));
            list.Add(new ListItem<int>("0天以上", 0));
            list.Add(new ListItem<int>("30天以上", 30));
            list.Add(new ListItem<int>("60天以上", 60));
            list.Add(new ListItem<int>("90天以上", 90));
            list.Add(new ListItem<int>("180天以上", 180));
            this.unconsumedComboBox.DisplayMember = "Key";
            this.unconsumedComboBox.ValueMember = "Value";
            this.unconsumedComboBox.DataSource = list;
        }
         
        public void WorkDeskCtrlSearch(TimeRange range)
        {
            //  this.skinCheckBox_showCurrentShopOnly.Checked = IsPos;
            //  this.skinCheckBox_showCurrentShopOnly.Visible = IsPos;
            String shopId = null;
            if (skinCheckBox_showCurrentShopOnly.Checked)
            {
                shopId = CommonGlobalCache.CurrentShopID;
            }

            skinComboBoxBigClass.SelectedValue = range;
            this.pagePara = new MemberListPagePara()
            {
                Ascend = false,
                ShopID = shopId,
                ColumnOrderby = Member._CreatedTime,
                TimeRange = (TimeRange)skinComboBoxBigClass.SelectedValue,
                PageIndex = 0,
                PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                PhoneNumberOrName = this.skinTextBox_ID.SkinTxt.Text.Trim(),
                NoRetailDay = (int)unconsumedComboBox.SelectedValue
            };

            Search();
        }

        private void SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BaseButton_Search_Click(null, null);
            }
        }

        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (this.pagePara == null)
                {
                    return;
                }
                this.pagePara.PageIndex = index;
                MemberListPage memberList = CommonGlobalCache.ServerProxy.GetMemberListPage(this.pagePara);
                this.BindingMemberDateSource(memberList);
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }
        }

        public override void RefreshPage()
        {
            //  BaseButton_Search_Click(null, null);

            if (this.pagePara != null)
            {
                dataGridViewPagingSumCtrl_CurrentPageIndexChanged(this.pagePara.PageIndex);
            }
        }

        String shopId = null;
        //点击搜索按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {

            this.pagePara = new MemberListPagePara()
            {
                Ascend = false,
                ShopID = shopId,
                ColumnOrderby = Member._CreatedTime,
                TimeRange = (TimeRange)skinComboBoxBigClass.SelectedValue,
                PageIndex = 0,
                PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                PhoneNumberOrName = this.skinTextBox_ID.SkinTxt.Text.Trim(),
                GuideID = ValidateUtil.CheckEmptyValue(guideComboBox1.SelectedValue),
                NoRetailDay = (int)unconsumedComboBox.SelectedValue
            };

            Search();
        }

        private void Search()
        {

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                MemberListPage listPage = CommonGlobalCache.ServerProxy.GetMemberListPage(this.pagePara);

                this.dataGridViewPagingSumCtrl.Initialize(listPage);
                this.BindingMemberDateSource(listPage);
            }
            catch (Exception ee)
            {

                ShowError(ee);
            }
            finally
            {
                UnLockPage();
            }
        }

        /// <summary>
        /// 绑定MemberList源到dataGridView 中
        /// </summary>
        /// <param name="memberListPage"></param>
        private void BindingMemberDateSource(MemberListPage listPage)
        {
            if (listPage != null && listPage.MemberArray != null && listPage.MemberArray.Count > 0)
            {
                this.SetMemberOtherValue(listPage.MemberArray);
            }
            dataGridViewPagingSumCtrl.BindingDataSource(listPage?.MemberArray, null, listPage?.TotalEntityCount, listPage?.MemberSum);
        }

        /// <summary>
        /// 将集合中GuideName赋值
        /// </summary>
        /// <param name="memberList"></param>
        private void SetMemberOtherValue(List<Member> memberList)
        {
            foreach (Member member in memberList)
            {
                member.GuideName = CommonGlobalCache.GetUserName(member.GuideID);
                Shop shop = CommonGlobalCache.GetShop(member.ShopID);
               // member.ShopName = shop == null ? "" : shop.Name;
            }
        }


        //第7列为 编辑按钮    第8列为消费历史按钮
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            // MessageBox.Show(string.Format("当前点中的是第{0}列，第{1}行", e.ColumnIndex, e.RowIndex));
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                List<Member> memberList = (List<Member>)this.dataGridView1.DataSource;

                switch (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    case "编辑":
                        if (this.UpdateMemberClick != null)
                        {
                            this.UpdateMemberClick(memberList[e.RowIndex], this);
                        }
                        break;
                    case "消费历史":
                        if (this.ConsumeHistoryClick != null)
                        {
                            RetailListPagePara para = new RetailListPagePara()
                            {
                                IsGetGeneralStore = true,
                                BrandID = -1,
                                RetailOrderID = null,
                                IsOpenDate = false, 
                                StartDate = null,
                                EndDate = null,
                                PageIndex = 0,
                                CostumeID = null,
                                PageSize = int.MaxValue,
                                RetailOrderType = RetailOrderType.All,
                                RetailOrderState = RetailOrderState.IsNormal,
                                ShopID = null,//所有店铺
                                RetailPayType = RetailPayType.All,
                                MemberID = memberList[e.RowIndex].PhoneNumber
                                
                            };
                            this.ConsumeHistoryClick(para, this,true);
                        }
                        break;
                    case "充值记录":
                        this.RechargeRecordClick?.Invoke(memberList[e.RowIndex], this);
                        break;
                    case "优惠券":
                        this.MemberGiftTicketClick?.Invoke(memberList[e.RowIndex], this);
                        break;
                }
            }
        }


        private void MemberManageCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
            if (HasPermission(RolePermissionEnum.查看_只看本店))
            { 
                skinCheckBox_showCurrentShopOnly.Enabled = false;

            }
            else
            {

                skinCheckBox_showCurrentShopOnly.Enabled = true;
            }
        }

        private void Initialize()
        {
            this.skinTextBox_ID.SkinTxt.Text = string.Empty;
            this.pagePara = new MemberListPagePara();
            this.dataGridViewPagingSumCtrl.Initialize(1);
            this.dataGridView1.DataSource = null;
        }

        private void BaseButtonAdd_Click(object sender, EventArgs e)
        {
            this.UpdateMemberClick(null, this);
        }


        private void baseButtonRecharge_Click(object sender, EventArgs e)
        {
            RechargeClick?.Invoke(null, this);
        }

        private void baseButtonSendGift_Click(object sender, EventArgs e)
        {
            this.SendGiftTicketClick?.Invoke(this);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                List<Member> memberList = (List<Member>)this.dataGridView1.DataSource;

                switch (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText)
                {
                    case "会员卡号":
                        ShowForm(memberList[e.RowIndex]);
                        break;
                }

            }
        }


        MemberDetailForm form = null;
        private void ShowForm(Member member)
        {
            if (form == null)
            {
                form = new MemberDetailForm();
            }
            form.ShowDialog(member);
        }


        private String path;
        private void DoExport()
        {
            try
            {
                List<CostumeStore> unableStore = new List<CostumeStore>();
                List<CostumeStore> stores = new List<CostumeStore>();
                List<Member> list = dataGridView1.DataSource as List<Member>;
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                DataGridViewColumn[] columns = new DataGridViewColumn[] {
            this.phoneNumberDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.sexNameDataGridViewTextBoxColumn,
            this.balanceDataGridViewTextBoxColumn1,
            this.currentIntegrationDataGridViewTextBoxColumn1,
            this.accruedIntegrationDataGridViewTextBoxColumn1,
            this.accruedSpendDataGridViewTextBoxColumn1,
            this.shopIDDataGridViewTextBoxColumn1,
            this.BuyCount,
            this.QuantityOfBuy,
            this.guideIDDataGridViewTextBoxColumn1,
            this.CreatedTime,
                 };
                foreach (var item in columns)
                {
                    if (item.Visible)
                    {
                        keys.Add(item.DataPropertyName);
                        values.Add(item.HeaderText);
                    }
                }

                NPOIHelper.Keys = keys.ToArray();
                NPOIHelper.Values = values.ToArray();//new System.Collections.SortedList();
                NPOIHelper.ExportExcel(DataGridViewUtil.ToDataTable(list), path);
                ShowMessage("导出完毕！");
            }
            catch (Exception ex)
            { CommonGlobalUtil.ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }


        private void baseButtonExport_Click(object sender, EventArgs e)
        {


            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "会员管理" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            if (String.IsNullOrEmpty(path))
            {
                return;
            }
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoExport);
                cb.BeginInvoke(null, null);
            }
            catch (Exception ex) { CommonGlobalUtil.ShowError(ex); }
        }

        private void skinComboBoxShopID_SelectedIndexChanged(object sender, EventArgs e)
        {
            shopId = (String)skinComboBoxShopID.SelectedValue;
            guideComboBox1.Initialize(GuideComboBoxInitializeType.All, shopId);
        }

        private void skinCheckBox_showCurrentShopOnly_CheckedChanged(object sender, EventArgs e)
        {
            /*  if (HasPermission(RolePermissionEnum.查看_只看本店))
              {
                  skinComboBoxShopID.Enabled = true;
              }*/
            
            if (skinCheckBox_showCurrentShopOnly.Checked )
            {
                skinComboBoxShopID.Enabled = false;
                skinComboBoxShopID.SelectedValue = CommonGlobalCache.CurrentShopID;
            }
            else
            {
                skinComboBoxShopID.Enabled = true;
            }
        }

        private String importShopID;
        private String importPath;

        private void form_ConfirmClick(string shopID, string path, MemberImportForm form)
        {
            importShopID = shopID;
            importPath = path;




            string fileExt = Path.GetExtension(path);
            if (fileExt != ".xlsx" && fileExt != ".xls")
            {
                ShowMessage("你所选择文件格式不正确，请重新上传文件！");
                return;
            }
            if (GlobalMessageBox.Show("是否开始导入" + System.IO.Path.GetFileName(path), "友情提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                importPath = null;
                importForm.Cancel();
                return;
            }

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoImport);
                cb.BeginInvoke(null, null);
            } 
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }


        #region 导入会员
        MemberImportForm importForm = null;
        private void baseButtonImport_Click(object sender, EventArgs e)
        {
            importForm = new MemberImportForm();
            importForm.CloseWhenEscape = false;
            importForm.ConfirmClick += form_ConfirmClick;
            if (importForm.ShowDialog() != DialogResult.OK)
            {
                importShopID = string.Empty;
                importPath = string.Empty;
                return;
            }

            //importPath = importForm.Path;
            //importShopID = importForm.ShopID;
        }


        private void DoImport()
        {
            try
            {
                List<Member> items = new List<Member>();
                List<Member> incorrectItems = new List<Member>();
                List<Member> checkTel = new List<Member>();
                List<Member> checkMemberNo = new List<Member>();  //导入时会员卡号不为数字或英文字母的集合
                List<int> checkMemberNoRow = new List<int>();
                DataTable dt = NPOIHelper.FormatToDatatable(importPath, 0);
                //20190223根据模板过滤第一行的注释和列标题
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    Member item = new Member();
                    try
                    {
                        if (!ImportValidate(row))
                        {
                            //20190218过滤第一列店铺列
                            int index = 1;
                            item.Index = i + 2;
                            item.ShopID = importShopID;
                            item.PhoneNumber = CommonGlobalUtil.ConvertToString(row[index++]);
                            item.Name = CommonGlobalUtil.ConvertToString(row[index++]);
                            item.Phone = CommonGlobalUtil.ConvertToString(row[index++]);
                            try
                            {
                                item.Sex = CommonGlobalUtil.ConvertToString(row[index++]) == "男";
                            }
                            catch
                            {
                                item.Sex = false;
                            }
                            try
                            {
                                item.Balance = Convert.ToDecimal(row[index++]);
                            }
                            catch
                            {
                                item.Balance = 0;
                            }
                            try
                            {
                                item.CurrentIntegration = Convert.ToInt32(row[index++]);
                            }
                            catch
                            {
                                item.CurrentIntegration = 0;
                            }
                            try
                            {
                                item.AccruedIntegration = Convert.ToInt32(row[index++]);
                            }
                            catch
                            {
                                item.AccruedIntegration = 0;
                            }
                            try
                            {
                                item.AccruedSpend = Convert.ToDecimal(row[index++]);
                            }
                            catch
                            {
                                item.AccruedSpend = 0;
                            }
                            try
                            {
                                item.BuyCount = Convert.ToInt32(row[index++]);
                            }
                            catch
                            {
                                item.BuyCount = 0;
                            }
                            try
                            {
                                item.QuantityOfBuy = Convert.ToInt32(row[index++]);
                            }
                            catch
                            {
                                item.BuyCount = 0;
                            }
                            item.GuideName = CommonGlobalUtil.ConvertToString(row[index++]);
                            item.GuideID = CommonGlobalCache.GetUserIDByUserName(item.GuideName);
                            item.CreatedTime = DateTimeUtil.ConvertToDateTime(CommonGlobalUtil.ConvertToString(row[index++]));
                            item.Birthday = DateTimeUtil.ConvertToDateTime(CommonGlobalUtil.ConvertToString(row[index++]));
                            item.State = 1;


                            if (!(String.IsNullOrEmpty(item.Name) && String.IsNullOrEmpty(item.PhoneNumber)))
                            {
                                items.Add(item);
                            }
                            if (checkPhoneNumber(item.PhoneNumber) == false)
                            {
                                checkMemberNo.Add(item);
                                checkMemberNoRow.Add(item.Index);
                            }
                            //else
                            //{
                            //    /*验证电话号码*/
                            //    if (!IstelNumber(item.PhoneNumber)) {
                            //        checkTel.Add(item);
                            //    }
                            //    incorrectItems.Add(item);
                            //}
                        }
                    }
                    catch
                    {
                        //   incorrectItems.Add(item);
                    }
                }

                if (incorrectItems.Count > 0)
                {
                    String str = string.Empty;
                    foreach (var item in incorrectItems)
                    {
                        str += item.Index + ",";
                    }
                    str = str.Substring(0, str.LastIndexOf(","));
                    ShowError("以下行数中，会员卡号/姓名为空，请重新检查！\r\n" + str);
                    ImportFormCancel();
                    return;
                }
                if (checkMemberNo.Count > 0)
                {
                    String rowStr = string.Empty;
                    for (int i=0; i< checkMemberNoRow.Count;i++)
                    {
                        rowStr += checkMemberNoRow[i] + ",";
                    }
                    rowStr = rowStr.Substring(0, rowStr.LastIndexOf(","));
                    ShowError("以下有效数据行数中，会员卡号格式错误，请重新检查！\r\n" + rowStr);
                    ImportFormCancel();
                    return;
                }
                /*  if (checkTel.Count > 0)
                  {
                      String telstr = string.Empty;
                      foreach (var item in checkTel)
                      {
                          telstr += item.Index + ",";
                      }
                      telstr = telstr.Substring(0, telstr.LastIndexOf(","));
                      ShowError("以下行数中，手机号码不正确，请重新检查！\r\n" + telstr);
                       ImportFormCancel();
                      return;
                  }*/

                if (items != null && items.Count > 0)
                {
                }
                else
                {
                    ShowMessage("没有数据可以导入，请检查会员信息！");
                    ImportFormCancel();
                    return;
                }

                InteractResult result = CommonGlobalCache.ServerProxy.ImportMembers(items);
                switch (result.ExeResult)
                {
                    case ExeResult.Success:
                        //导入
                        ImportFormDialogResult(DialogResult.OK);
                        ShowMessage("导入成功！");
                        //importForm.DialogResult = DialogResult.OK;
                        break;
                    case ExeResult.Error:
                        ShowMessage(result.Msg);
                        // ImportFormDialogResult(DialogResult.OK);
                        ImportFormCancel();
                        break;
                    default:
                        break;
                }
            }
          
            catch (Exception ex)
            {
                ImportFormCancel();
                ShowError(ex);
            }
            finally
            {
                UnLockPage();
            }
        }
        /// <summary>
        /// 检查会员卡号是否正确（允许英文和数字，不能为中文）
        /// </summary>
        /// <param name="memberNo"></param>
        /// <returns></returns>
        public bool checkPhoneNumber(string memberNo)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(memberNo, @"^[A-Za-z0-9]*$");
        }

        /// <summary>
        /// 检查电话号码是否正确
        /// </summary>
        /// <param name="str_handset"></param>
        /// <returns></returns>
        public bool IstelNumber(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+[3,5]+\d{9}");
        }

        private bool ImportValidate(DataRow row)
        {
            //
            bool unValidate = true;
            for (int i = 0; i < 13; i++)
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

        #endregion
        private void ImportFormCancel()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric(this.ImportFormCancel));
            }
            else
            {
                importForm.Cancel();
            }
        }

        private void ImportFormDialogResult(DialogResult result)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<DialogResult>(this.ImportFormDialogResult), result);
            }
            else
            {
                importForm.DialogResult = result;
            }
        }





        private void baseButtonDownTemplate_Click(object sender, EventArgs e)
        {
            //找到EXCEL模板文件
            String sourceFile = System.Environment.CurrentDirectory + "\\Templates\\importMember.xls";
            String path = "";
            path = FileUtil.BrowseFolder("请选择保存模板的位置");
            if (String.IsNullOrEmpty(path))
            {
                return;
            }

            String toPath = path + "\\会员导入模板.xls";
            System.IO.File.Copy(sourceFile, toPath, true);
            GlobalMessageBox.Show("模板保存" + toPath + "！");
        }

        private void skinPanelSendGift_Paint(object sender, PaintEventArgs e)
        {

        }

        private void unconsumedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void downTemplateButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
