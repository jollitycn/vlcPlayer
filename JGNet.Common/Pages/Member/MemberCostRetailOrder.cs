using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Core.InteractEntity;
using CCWin;  
using JGNet.Common.Core;  
using CCWin.SkinControl;
using CJBasic;
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using JGNet.Core.Const;
using JGNet.Core.Tools;
using JGNet.Core;

namespace JGNet.Common
{
    public partial class MemberCostRetailOrder : BaseForm 
    { 

        private RetailListPagePara pagePara;
        public CJBasic.Action<RetailOrder, BaseUserControl> RedoClick;
        public  CJBasic.Action<String, BaseUserControl> RefundDetailClick;
        public CJBasic.Action<String, BaseUserControl> RetailDetailClick;
        private string memberId;
        private int DateInt;
        private string shopID;
        public DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public MemberCostRetailOrder()
        {
            InitializeComponent(); 
        }  

         

     
         
    

        private void SetPayType()
        {
            List<ListItem<RetailPayType>> list = new List<ListItem<RetailPayType>>();
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.All), RetailPayType.All));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.Cash), RetailPayType.Cash));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.BankCard), RetailPayType.BankCard));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.WeiXin), RetailPayType.WeiXin));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.Alipay), RetailPayType.Alipay));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.VipCard), RetailPayType.VipCard));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.Ticket), RetailPayType.Ticket));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.Other), RetailPayType.Other));
           
        }

    

        private void BaseButton_resetReport_Click(object sender, EventArgs e)
        {
           /* try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                CreateAllReportSelectForm form = new CreateAllReportSelectForm("重结报表", "开始日期：", this.dateTimePicker_Start.Value, "正在重新结算中……");
                form.ConfirmClick += form_ConfirmClick;
                form.ShowDialog();

            }
            catch (Exception ee)
            {


                CommonGlobalUtil.ShowError(ee);
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }*/
        }

        CreateAllReportSelectForm form = null;
        DateTime dateTime = DateTime.Now;
        String createAllReportParaShopId;
        private void form_ConfirmClick(DateTime dateTime,String shopId, CreateAllReportSelectForm form)
        {

           /* try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                this.dateTime = dateTime;
                createAllReportParaShopId = shopId;
                this.form = form;
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoUpdate);
                cb.BeginInvoke(null, null); ShowProgressForm();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }*/

        }


        private void DoUpdate()
        {
          /*  try
            {
                
                int days = TimeHelper.GetSpanDays(dateTime, DateTime.Now);
                days = days + 1;
                int i = 0;
                for (i = 0; i < days; i++)
                {
                    if (progressStop)
                    {
                        break;
                    }

                    DateTime oneDate = dateTime.AddDays(i * 1.0);
                    CreateAllReportPara para = new CreateAllReportPara()
                    {
                        Date = new Date(oneDate),
                        ShopId = createAllReportParaShopId
                    };

                    UpdateProgress(days, i + 1);
                    InteractResult result = CommonGlobalCache.ServerProxy.CreateAllReport(para);
                    switch (result.ExeResult)
                    {
                        case ExeResult.Success:
                            break;
                        case ExeResult.Error:
                            FailedProgress(new Exception(result.Msg));
                            CompleteEdit(true);
                            return;
                        default:
                            break;
                    }
                }
                CompleteEdit();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                UnLockPage();
            }*/
        }

         
        private void CompleteEdit(bool stop=false)
        {
            /*if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<bool>(this.CompleteEdit),stop);
            }
            else
            {
                CompleteProgressForm();
                if (stop)
                {
                    form.Cancel();
                }
                else
                {
                    form.SetDialogResult(DialogResult.OK);
                    GlobalMessageBox.Show("重结成功！");
                }
            }*/
        }

          

        //点击查询按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
           /* string orderID = this.skinTextBox_OrderID.SkinTxt.Text.Trim();
            orderID = string.IsNullOrEmpty(orderID) ? null : orderID;
            string costumeID = this.CostumeCurrentShopTextBox1.SkinTxt.Text;
            costumeID = string.IsNullOrEmpty(costumeID) ? null : costumeID;
            bool isOpenDate = true;
            Date startDate = new Date(this.dateTimePicker_Start.Value);
            Date endDate = new Date(this.dateTimePicker_End.Value);
             
            this.pagePara = new RetailListPagePara()
            {
                RetailOrderState = (RetailOrderState)this.skinComboBoxState.SelectedValue,
                RetailOrderID = orderID,
                CostumeID = costumeID,
                StartDate = startDate,
                EndDate = endDate,
                ClassID = skinComboBoxBigClass.SelectedValue.ClassID,
                //SubSmallClass = skinComboBoxBigClass.SelectedValue?.SubSmallClass,
                BrandID = (int)this.skinComboBox_Brand.SelectedValue,
                IsOpenDate = isOpenDate,
                PageIndex = 0,
                PageSize = this.retailOrderListCtrl2.dataGridViewPagingSumCtrl.PageSize,
                RetailOrderType = (RetailOrderType)this.skinComboBox_type.SelectedValue,
                IsGetGeneralStore = CommonGlobalCache.IsGeneralStoreRetail == "1",
                ShopID = shopID,
                GuideID = ValidateUtil.CheckEmptyValue(this.guideComboBox1.SelectedValue),
                RetailPayType = (RetailPayType)this.brandComboBoxPayType.SelectedValue,
            };
            Search();*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="para">内部调用的话不传</param>
        public void Search(RetailListPagePara para=null)
        {

            InteractResult<List<RetailOrder>> memberList = CommonGlobalCache.ServerProxy.GetReatilOrders(this.memberId, this.DateInt);


           // ListPage = CommonGlobalCache.ServerProxy.GetRetailListPage(pagePara);
           // this.dataGridViewPagingSumCtrl.Initialize(memberList);
           // this.BindingRetailOrderDataSource();

            /* if (para != null) { 
            this.pagePara = para;
            SetQueryCondition();
            }
           try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                Shop shop= this.skinComboBoxShopID.SelectedItem as Shop;
                retailOrderListCtrl2.RedoClick = RedoClick;
                retailOrderListCtrl2.RefundDetailClick = RefundDetailClick;
                retailOrderListCtrl2.RetailDetailClick = RetailDetailClick;
                retailOrderListCtrl2.SourceCtrlType = this;
                this.retailOrderListCtrl2.BindingSource(pagePara, shop.Name==SystemDefault.onlineName);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }*/
        }

        private void SetQueryCondition()
        {

          /*  this.skinTextBox_OrderID.SkinTxt.Text = pagePara.RetailOrderID;
            this.CostumeCurrentShopTextBox1.SkinTxt.Text = pagePara.CostumeID;
            this.dateTimePicker_Start.Value = pagePara.StartDate.ToDateTime();
            this.dateTimePicker_End.Value = pagePara.EndDate.ToDateTime();
            skinComboBoxBigClass.SelectedValue = new Costume() {
                ClassID = pagePara.ClassID
                };
                skinComboBox_Brand.SelectedValue = pagePara.BrandID;
        
            if (!String.IsNullOrEmpty(pagePara.ShopID))
            { 
                skinComboBoxShopID.SelectedValue = pagePara.ShopID;
            }
            if (!String.IsNullOrEmpty(pagePara.GuideID))
            {
                guideComboBox1.SelectedValue = pagePara.GuideID;
            }
            skinComboBox_type.SelectedValue = pagePara.RetailOrderType;*/
        }

        private void RetailOrderSearchCtrl_Load(object sender, EventArgs e)
        {
         //   this.Initialize();
           // retailOrderListCtrl2.Show();
        }

     

       

      
    }
}
