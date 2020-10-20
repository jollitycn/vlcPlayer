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

namespace JGNet.Common
{
    public partial class MemberRechargeRecordDetail : BaseForm
    {

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private MemberBalanceChange Memberitem;
        private string memberPhone;
        private bool readOnly;
        public MemberRechargeRecordDetail()
        {
            InitializeComponent();
            InitializeConstruct();
        }
        private void InitializeConstruct()
        {
             
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new String[] {
            this.DonateMoney.DataPropertyName,
            this.BalanceNew.DataPropertyName,
            this.BalanceOld.DataPropertyName,
            this.RechargeMoney.DataPropertyName
            });
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewPagingSumCtrl.Initialize();
          
        }

        private void Search(object sender, EventArgs args)
        {

        }
       /* private void BindingSource(List<ReatilSumInfo> listPage)
        {
          //  this.dataGridViewPagingSumCtrl.BindingDataSource(listPage);
        }*/

        //点击搜索按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {

            
           /* this.pagePara = new RechargeRecordListPara()
            {
                IsPos = false,
                ShopID = null
            };*/

            /* List<RechargeRecord> memberList = CommonGlobalCache.ServerProxy.GetRechargeRecordList(this.pagePara);
            
           List<ReatilSumInfo> allList = memberList.Data;
           decimal AllSum = 0;
           ReatilSumInfo totalSum = new ReatilSumInfo();
          foreach (var item in allList)
           {
               AllSum += item.Money;
           }
           totalSum.MemberID = "总计";
           totalSum.Money = AllSum;
           allList.Add(totalSum);
           
            dataGridViewPagingSumCtrl.BindingDataSource(memberList);*/
            // dataGridViewPagingSumCtrl.OrderSearch = this.pagePara;


        }
        internal DialogResult ShowDialog(MemberBalanceChange item, string memberId , bool readOnly)
        {

            this.Memberitem = item;
            this.memberPhone = memberId;
             return this.ShowDialog();

        }



        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            InteractResult<List<RechargeRecord>> memberList = CommonGlobalCache.ServerProxy.GetRechargeRecords4Day(this.memberPhone, Memberitem.DateInt);
            dataGridViewPagingSumCtrl.BindingDataSource(memberList.Data);
        }





        private void MemberconsumptionSearch_Load(object sender, EventArgs e)
        {
            InteractResult<List<RechargeRecord>> memberList = CommonGlobalCache.ServerProxy.GetRechargeRecords4Day(this.memberPhone, Memberitem.DateInt);
            dataGridViewPagingSumCtrl.BindingDataSource(memberList.Data);

        }

       
    }
}
