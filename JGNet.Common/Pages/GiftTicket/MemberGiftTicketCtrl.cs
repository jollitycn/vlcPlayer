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
using JGNet.Common.Components;
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Core.Tools;
using JGNet.Common.Core.Util;

namespace JGNet.Common
{
    public partial class MemberGiftTicketCtrl : BaseModifyUserControl
    {


        private GiftTicketPagePara pagePara;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;


        private Member member;

        public MemberGiftTicketCtrl()
        {
            InitializeComponent();
            InitializeConstruct();
            MenuPermission = RolePermissionMenuEnum.优惠券管理;
        }
        private void InitializeConstruct()
        {
            skinTextBox_ID.SkinTxt.KeyDown += SkinTxt_KeyDown;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, this.BaseButton_Search_Click,new String[] {
            denominationDataGridViewTextBoxColumn.DataPropertyName
            });
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 Remarks });
            dataGridViewPagingSumCtrl.Initialize(); 
         
            dataGridViewPagingSumCtrl.OrderSearch = Search;
            SetState();
            Display();
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
        }

        private void Search(object sender, EventArgs args)
        {

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                GiftTicketPage listPage = CommonGlobalCache.ServerProxy.GetGiftTicketPage(this.pagePara);
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
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

        //点击搜索按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {

            this.pagePara = new GiftTicketPagePara()
            {  
                PageIndex = 0,
                PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                MemberID = skinTextBoxMemberId.Text,
                GiftTicketID = skinTextBox_ID.Text,
                GiftTicketState = (GiftTicketState)this.skinComboBoxState.SelectedValue,
                EndDate = new Date(this.dateTimePicker_End.Value),
                StartDate = new Date(this.dateTimePicker_Start.Value),
            };

            if (IsPos)
            {
                pagePara.IsPos = true;
                pagePara.ShopID = CommonGlobalCache.CurrentShopID;
            }

            dataGridViewPagingSumCtrl.OrderPara = pagePara;
            Search(sender, e);
        }

        public MemberGiftTicketCtrl(Member member)
        {
            InitializeComponent();
            this.member = member;
            effectDateDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATE_FORMAT;
            expiredDateDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATE_FORMAT;
            InitializeConstruct();

        }




        private void Display()
        {
            if (member != null)
            {
                skinLabelMemberName.Text = member.Name;
                skinTextBoxMemberId.Text = member.PhoneNumber;
            }
            else
            {
                skinLabelMemberName.Text = string.Empty;
            }
        }

        private void SetState()
        {
            List<ListItem<GiftTicketState>> stateList = new List<ListItem<GiftTicketState>>();
            stateList.Add(new ListItem<GiftTicketState>(EnumHelper.GetDescription(GiftTicketState.All), GiftTicketState.All));
            stateList.Add(new ListItem<GiftTicketState>(EnumHelper.GetDescription(GiftTicketState.IsNotUse), GiftTicketState.IsNotUse));
            stateList.Add(new ListItem<GiftTicketState>(EnumHelper.GetDescription(GiftTicketState.IsUse), GiftTicketState.IsUse));

            this.skinComboBoxState.DisplayMember = "Key";
            this.skinComboBoxState.ValueMember = "Value";
            this.skinComboBoxState.DataSource = stateList;

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
                GiftTicketPage memberList = CommonGlobalCache.ServerProxy.GetGiftTicketPage(this.pagePara);
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
        /// <summary>
        /// 绑定MemberList源到dataGridView 中
        /// </summary>
        /// <param name="memberListPage"></param>
        private void BindingMemberDateSource(GiftTicketPage memberListPage)
        {
            //  this.dataGridView1.DataSource = null;
            if (memberListPage != null && memberListPage.GiftTickets != null && memberListPage.GiftTickets.Count > 0)
            {
                this.SetMemberOtherValue(memberListPage.GiftTickets);
            }

            dataGridViewPagingSumCtrl.BindingDataSource(memberListPage?.GiftTickets, null, memberListPage?.TotalEntityCount, memberListPage?.GiftTicketSum);

            this.dataGridView1.Refresh();
        }

        /// <summary>
        /// 将集合中GuideName赋值
        /// </summary>
        /// <param name="memberList"></param>
        private void SetMemberOtherValue(List<GiftTicket> memberList)
        {
            foreach (GiftTicket member in memberList)
            {
                // member.GuideName = CommonGlobalCache.GetUserName(member.GuideID);
                Shop shop = CommonGlobalCache.GetShop(member.ShopID);
                member.ShopName = shop == null ? "" : shop.Name;
                
            }
        }




        private void MemberGiftTicketCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
            if (member != null)
            {
                BaseButton_Search_Click(null, null);
            }
        }

        private void Initialize()
        {
            this.skinTextBox_ID.SkinTxt.Text = string.Empty;
            this.pagePara = new GiftTicketPagePara();
           this.dataGridViewPagingSumCtrl.Initialize(1);
            this.dataGridView1.DataSource = null;
        }

        private void skinTextBoxMemberId_MemberSelected(Member obj)
        {
            if (obj != null)
            {
                member = obj;
            }
            Display();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridView1.Rows[e.RowIndex].IsNewRow)
            //    {
            //        DataGridView view = (DataGridView)sender;
            //        List<GiftTicket> list = (List<GiftTicket>)view.DataSource;
            //        GiftTicket item = (GiftTicket)list[e.RowIndex];
            //        switch (view.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText)
            //        {
            //            case "禁用":

            //                if (item.StateName == "已使用") {
            //                    GlobalMessageBox.Show("已使用的优惠券不能禁用！" + this.dataGridView1[e.ColumnIndex, e.RowIndex].Value);

            //                    dataGridView1.CancelEdit();

            //                    //dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            //                    //this.dataGridView1[e.ColumnIndex, e.RowIndex].Value = false;
            //                    //dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            //                    //dataGridView1.Refresh();
            //                    return;
            //                }

            //                if (GlobalMessageBox.Show("是否确认操作？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //                {

            //                    item.Enabled = (bool)this.dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            //                    DoEnable(item);
            //                }
            //                else
            //                {
            //                    dataGridView1.CancelEdit();
            //                    return;
            //                }


            //                break;
            //            default: break;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    CommonGlobalUtil.ShowError(ex);
            //}
        }

        private void DoEnable(GiftTicket item)
        {
            try
            {

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                EnabledGiftTicketPara para = new EnabledGiftTicketPara()
                {
                    Enabled = item.Enabled,
                    ID = item.ID
                };
                UpdateResult result = CommonGlobalCache.ServerProxy.EnabledGiftTicket(para);
                switch (result)
                {
                    case UpdateResult.Success:
                        break;
                    case UpdateResult.Error:
                        GlobalMessageBox.Show("内部错误！");
                        break;
                    default:
                        break;
                }
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

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                //  dataGridView1.CommitEdit( DataGridViewDataErrorContexts.)
                //    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridView1.Rows[e.RowIndex].IsNewRow)
                {
                    DataGridView view = (DataGridView)sender;
                    List<GiftTicket> list = (List<GiftTicket>)view.DataSource;
                    GiftTicket item = (GiftTicket)list[e.RowIndex];
                    switch (view.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText)
                    {
                        case "禁用":
                            
                                if (item.StateName == "已使用")
                                {
                                    GlobalMessageBox.Show("已使用的优惠券不能禁用！");

                                    dataGridView1.CancelEdit();

                                    //dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
                                    //this.dataGridView1[e.ColumnIndex, e.RowIndex].Value = false;
                                    //dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
                                    //dataGridView1.Refresh();
                                    return;
                                }

                                if (GlobalMessageBox.Show("是否确认操作？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {

                                    item.Enabled = !item.Enabled;
                                    DoEnable(item);
                                }
                                else
                                {
                                    dataGridView1.CancelEdit();
                                    return;
                                }
                            break;
                        default: break;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0) { return; }

            //GiftTicket ticket = dataGridView1.Rows[e.RowIndex].DataBoundItem as GiftTicket;
            //if (e.ColumnIndex == Column1.Index)
            //{
            //    e.Value = ticket.StateName;
            //}
            //else if (e.ColumnIndex == shopIDDataGridViewTextBoxColumn.Index)
            //{
            //    e.Value = ticket.ShopName;
            //}
        }

        public event Action<BaseUserControl> SendGiftTicketClick;
        private void baseButtonSendGift_Click(object sender, EventArgs e)
        {
            this.SendGiftTicketClick?.Invoke(this);
        }
    }
}
