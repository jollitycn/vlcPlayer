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
    public partial class MemberconsumptionSearch : BaseModifyUserControl
    {


        private GetReatilSumInfoPara pagePara;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;


        private Member member;

        public MemberconsumptionSearch()
        {
            InitializeComponent();
            InitializeConstruct();
            MenuPermission = RolePermissionMenuEnum.会员消费汇总;
        }
        private void InitializeConstruct()
        {
           // dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1);
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new String[] { 
            this.moneyDataGridViewTextBoxColumn.DataPropertyName
            });
            dataGridView1.AutoGenerateColumns = false;
            dataGridViewPagingSumCtrl.Initialize();
            SetState();
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
        }

        private void Search(object sender, EventArgs args)
        {

        }
        private void BindingSource(List<ReatilSumInfo> listPage)
        {
            //  this.dataGridViewPagingSumCtrl.BindingDataSource(DataGridViewUtil.ToDataTable(listPage),null);
            dataGridViewPagingSumCtrl.BindingDataSource<ReatilSumInfo>(DataGridViewUtil.ListToBindingList(listPage));
        }

        //点击搜索按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {

           this.pagePara = new GetReatilSumInfoPara()
            {  
                MemberID = skinTextBoxMemberId.Text,
               Type = (ReatilSumInfoType)this.skinComboBoxtype.SelectedValue,
                EndDate = new Date(this.dateTimePicker_End.Value),
                StartDate = new Date(this.dateTimePicker_Start.Value),
            };


            if ((ReatilSumInfoType)this.skinComboBoxtype.SelectedValue == ReatilSumInfoType.MemberShop)
            {
                this.ShopName.Visible = true;
            }
            else
            {
                this.ShopName.Visible = false;
            }
            InteractResult<List<ReatilSumInfo>> memberList = CommonGlobalCache.ServerProxy.GetReatilSumInfo(this.pagePara);
             /*List<ReatilSumInfo> allList = memberList.Data;
            decimal AllSum = 0;
            ReatilSumInfo totalSum = new ReatilSumInfo();
           foreach (var item in allList)
            {
                AllSum += item.Money;
            }
            totalSum.MemberID = "总计";
            totalSum.Money = AllSum;
            allList.Add(totalSum);
            */
         //   dataGridViewPagingSumCtrl.BindingDataSource(memberList.Data);
            dataGridViewPagingSumCtrl.BindingDataSource<ReatilSumInfo>(DataGridViewUtil.ListToBindingList(memberList.Data));
            // dataGridViewPagingSumCtrl.OrderSearch = this.pagePara;


        }


        private void SetState()
        {
            List<ListItem<ReatilSumInfoType>> stateList = new List<ListItem<ReatilSumInfoType>>();
            stateList.Add(new ListItem<ReatilSumInfoType>(EnumHelper.GetDescription(ReatilSumInfoType.Member), ReatilSumInfoType.Member));
            stateList.Add(new ListItem<ReatilSumInfoType>(EnumHelper.GetDescription(ReatilSumInfoType.MemberShop), ReatilSumInfoType.MemberShop));

            this.skinComboBoxtype.DisplayMember = "Key";
            this.skinComboBoxtype.ValueMember = "Value";
            this.skinComboBoxtype.DataSource = stateList;

        }

       
        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (this.pagePara == null)
                {
                    return;
                }
                InteractResult<List<ReatilSumInfo>> memberList = CommonGlobalCache.ServerProxy.GetReatilSumInfo(this.pagePara);
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }
        }





        private void MemberconsumptionSearch_Load(object sender, EventArgs e)
        {
            this.Initialize();
            if (member != null)
            {
                BaseButton_Search_Click(null, null);
            }
        }

        private void Initialize()
        {
          /*  this.skinTextBox_ID.SkinTxt.Text = string.Empty;*/
           /* this.pagePara = new  GetReatilSumInfoPara();
             this.dataGridViewPagingSumCtrl.Initialize(1);
            this.dataGridView1.DataSource = null;*/

        }

        private void skinTextBoxMemberId_MemberSelected(Member obj)
        {
            if (obj != null)
            {
                member = obj;
            }
          
        }

    }
}
