using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Core;
using CCWin;
using JGNet.Common.Core.Util;
using System.Reflection;
using CJBasic.Loggers;
using JGNet.Common.Core;  
using JGNet.Common.Components;
using CCWin.SkinControl;
using JGNet.Core.Tools;
using JGNet.Common.Models;
using JGNet.Common;
using JGNet.Core.InteractEntity;

namespace JGNet.Manage.Pages.BasicSettings.Costume
{
    public partial class SendGiftTicketCtrl : BaseModifyUserControl
    {

        public static String MANAGE_CONFIG_PATH = CommonGlobalUtil.AgileConfiguration("Manage//GiftTicket");
        //   public static String POS_CONFIG_PATH = CommonGlobalUtil.AgileConfiguration("Pos//GiftTicket");
        private String CONFIG_PATH = String.Empty;
        private GiftTicket GiftTicket;
        private GiftTicketAgileConfiguration config;
        private List<Member> members;
        public SendGiftTicketCtrl()
        {
            InitializeComponent();

            new DataGridViewPagingSumCtrl(this.dataGridViewMembers).Initialize();
            dataGridViewMembers.AutoGenerateColumns = false;
            CONFIG_PATH = MANAGE_CONFIG_PATH;
        }

        private void Initialize()
        {
            this.skinTextBoxMemberId.SkinTxt.Text = string.Empty;
            this.dataGridViewMembers.AutoGenerateColumns = false;
            DateTimeUtil.DateTimePicker_GetTodayAndAfterAMonth(dateTimePickerStartDate, dateTimePickerEndDate);
            SetGiftTicket(this.skinComboBox_giftTicket);
           // guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, CommonGlobalCache.CurrentShopID);

            //if (CommonGlobalCache.CurrentUser.Type == UserInfoType.Guide)
            //{
            //    this.guideComboBox1.SelectedValue = CommonGlobalCache.CurrentUserID;
            //}
            try
            {
                config = GiftTicketAgileConfiguration.Load(CONFIG_PATH) as GiftTicketAgileConfiguration;
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.WriteLog(ex);
            }
            GiftTicket = config?.GiftTicket;
            if (GiftTicket != null)
            {
                while (GiftTicket.ExpiredDate < TimeHelper.GetDateTimeWithEmptyTime(DateTime.Now))
                {
                    GiftTicket.ExpiredDate = GiftTicket.ExpiredDate.AddMonths(1);
                }
                dateTimePickerEndDate.Value = GiftTicket.ExpiredDate;


            }
            else
            {
                GiftTicket = new GiftTicket();
                config = new GiftTicketAgileConfiguration();
            }
        }

        private void SetGiftTicket(SkinComboBox skinComboBox_giftTicket)
        {
            try
            {

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                List<GiftTicketTemplate> templates = CommonGlobalCache.ServerProxy.GetGiftTicketTemplates();

                skinComboBox_giftTicket.DataSource = null;
                skinComboBox_giftTicket.DisplayMember = "DenominationAndTickDesc";
                skinComboBox_giftTicket.ValueMember = "AutoID";
                skinComboBox_giftTicket.DataSource = templates;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                UnLockPage();
            }


        }

        private void SendGiftTicketCtrl_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void skinTextBoxMemberId_MemberSelected(Member obj)
        {
            if (obj != null)
            {
                if (members == null)
                {
                    members = new List<Member>();
                    
                }

                if (!this.members.Exists(t => t.PhoneNumber == obj.PhoneNumber))
                {
                    members.Add(obj);
                }
               
               
                BindingDataSource();
            }
        }
        private void BindingDataSource()
        {
            dataGridViewMembers.DataSource = null;
            if (this.members != null)
            {
                dataGridViewMembers.DataSource = members;
            }
        }

        private void skinComboBox_giftTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            GiftTicketTemplate template = skinComboBox_giftTicket.SelectedItem as GiftTicketTemplate;
            skinTextBoxMoney.Text = template.Denomination.ToString();
        }

        private void baseButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValidate()) { return; }
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                List<String> memberIds = new List<string>();
                foreach (var item in members)
                {
                    memberIds.Add(item.PhoneNumber);
                }

                Core.InteractEntity.IssueGiftTicketPara para = new Core.InteractEntity.IssueGiftTicketPara()
                {
                    IssueCount = Decimal.ToInt32(this.textBoxCount.Value),
                    MemberIDs = memberIds,
                    EffectDate = new CJBasic.Date(this.dateTimePickerStartDate.Value),
                    ExpiredDate = new CJBasic.Date(this.dateTimePickerEndDate.Value),
                    OperatorUserID = CommonGlobalCache.CurrentUserID,
                    GiftTicketTemplateID = (int)skinComboBox_giftTicket.SelectedValue,
                    Remarks = textBoxRemarks.Text,
                };
                GiftTicket.ExpiredDate = this.dateTimePickerEndDate.Value;

                while (GiftTicket.ExpiredDate < TimeHelper.GetDateTimeWithEmptyTime(DateTime.Now))
                {
                    GiftTicket.ExpiredDate = GiftTicket.ExpiredDate.AddMonths(1);
                }
                para.ExpiredDate = new CJBasic.Date(GiftTicket.ExpiredDate);
                InsertResult result = CommonGlobalCache.ServerProxy.IssueGiftTicket(para);
                switch (result)
                {
                    case InsertResult.Success:
                        GlobalMessageBox.Show(this.FindForm(), "发放成功！");
                        config.GiftTicket = GiftTicket;
                        config.Save(CONFIG_PATH);
                        // TabPageClose(this.CurrentTabPage, this.SourceCtrlType);
                        break;
                    case InsertResult.Error:
                        GlobalMessageBox.Show(this.FindForm(), "内部错误！");
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                UnLockPage();
            }
        }

        private bool CheckValidate()
        {
            bool success = true;
            string msg = string.Empty;

          /*  if (guideComboBox1.SelectedValue.ToString() == "-1")
            {
                msg = "请选择操作人"; success = false;
            }
            else*/ if (members == null || members.Count == 0)
            {
                msg = "请添加会员信息"; success = false;
            }

            if (!success)
            {
                GlobalMessageBox.Show(this.FindForm(), msg);
            }
            return success;
        }

        private void dataGridViewMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; }
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    List<Member> list = (List<Member>)this.dataGridViewMembers.DataSource;
                    Member item = (Member)list[e.RowIndex];
                    switch (this.dataGridViewMembers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                    {

                        case "删除":
                            this.dataGridViewMembers.DataSource = null;
                            list.Remove(item);
                            this.dataGridViewMembers.DataSource = list;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void BaseButton6_Click(object sender, EventArgs e)
        {
            MemberMultiSelectForm multiselectForm = new MemberMultiSelectForm();
            multiselectForm.MemberMultiSelected += MemberMultiSelected;
            multiselectForm.ShowDialog();
        }

        private void MemberMultiSelected(List<Member> returnMembers)
        {
            if (members == null)
            {
                members = new List<Member>();
            }
            foreach (var item in returnMembers)
            {
                if (!this.members.Exists(t => t.PhoneNumber == item.PhoneNumber))
                {
                    members.Add(item);
                }
            }
            BindingDataSource();
        }
    }
}
 
