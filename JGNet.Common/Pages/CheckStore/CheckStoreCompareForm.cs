using CCWin.SkinControl;
using JGNet.Common;
using JGNet.Common.Core;  
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;
using JGNet.Common.Components;
using JGNet.Common.Core.Util;
using JGNet.Common.Models;
using CJBasic.Helpers;
using JGNet.Core;
using CJBasic;
using JGNet.Core.Dev.InteractEntity;

namespace JGNet.Common
{
    public partial class CheckStoreCompareForm : Common.BaseForm
    {

        public event CJBasic.Action<List<CheckStoreDetail>, EventArgs> SameWithStoreClick;

        public event CJBasic.Action<List<CheckStoreDetail>, EventArgs> ZeroClick;
        private NewMemberCtrl ctrl = null;
        public Member member { get; set; }
        private String shopId;
        private DateTime date;
        private List<CheckStoreDetail> costumeStores;
        public List<CheckStoreDetail> unshowStores { get; set; }//相符不显示的
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl1;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl2;
         List<CostumeStoreHistory> shots = null;

        public CheckStoreCompareForm(String shopId, DateTime date, List<CheckStoreDetail> costumeStores)
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new string[] {
            this.costumeIDDataGridViewTextBoxColumn.DataPropertyName,
        FAtm.DataPropertyName,
         XSAtm.DataPropertyName,
         SAtm.DataPropertyName,
         MAtm.DataPropertyName,
         LAtm.DataPropertyName,
             XLAtm.DataPropertyName,
         XL2Atm.DataPropertyName,
         XL3Atm.DataPropertyName,
         XL4Atm.DataPropertyName,
         XL5Atm.DataPropertyName,
         XL6Atm.DataPropertyName
    });
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl1 = new DataGridViewPagingSumCtrl(this.dataGridView2, new string[] {
                 dataGridViewTextBoxColumn4.DataPropertyName,
       dataGridViewTextBoxColumn5.DataPropertyName,
       dataGridViewTextBoxColumn6.DataPropertyName,
       dataGridViewTextBoxColumn7.DataPropertyName,
       dataGridViewTextBoxColumn8.DataPropertyName,
       dataGridViewTextBoxColumn9.DataPropertyName,
       dataGridViewTextBoxColumn10.DataPropertyName,
       dataGridViewTextBoxColumn11.DataPropertyName,
       dataGridViewTextBoxColumn12.DataPropertyName,
       dataGridViewTextBoxColumn13.DataPropertyName,
       dataGridViewTextBoxColumn14.DataPropertyName,
            dataGridViewTextBoxColumn15.DataPropertyName});
            dataGridViewPagingSumCtrl1.Initialize();
            dataGridView3.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridViewPagingSumCtrl2 = new DataGridViewPagingSumCtrl(this.dataGridView3, new string[] {
            QuickCount.DataPropertyName,
            RealCount.DataPropertyName,
            DiffCount.DataPropertyName});
            dataGridViewPagingSumCtrl2.Initialize();

            this.shopId = shopId;
            this.date = date;
            this.costumeStores = costumeStores;
            this.tabControl1.SelectedIndex = 0;

            MenuPermission = RolePermissionMenuEnum.盘点录入;
            //if (!HasPermission(Core.RolePermissionEnum.查看_品牌))
            //{ 
            //    skinComboBox_Brand.Enabled = false;
            //}

        } 

        private void Initialize()
        {
            CommonGlobalUtil.SetBrand(this.skinComboBox_Brand);
            tabControl1_SelectedIndexChanged(null, null);
            GlobalMessageBox.Show("当前还有 【" + uncheckList?.Count + "】 条商品记录未进行盘点！\r\n" +
             "若未盘点的商品库存确实不存在，请做【盘点数=0】的确认操作！", "盘点提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
         
        }

        public void ShowDialog(Member member)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                this.member = member;
                this.skinPanel1.Controls.Remove(ctrl);
                ctrl = new NewMemberCtrl();
                ctrl.Dock = DockStyle.Fill;
                this.skinPanel1.Controls.Add(ctrl);
                Display();
            }
            catch (Exception ee)
            {

                ShowError(ee);
            }
            finally
            {
                UnLockPage();
                this.TopMost = true;
                this.Show();
                this.TopMost = false;
            }
        }
        private void Display()
        {
            //  ctrl.Hide();
            ctrl.DisplayMember(member);
        }

        private void MemberDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        List<CheckStoreDetail> uncheckList = null;

        private void ToCheckStoreDetail(CheckStoreDetail detail, CostumeStoreHistory item)
        {
            if (item != null)
            {
                Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
                if (costume != null)
                {
                    detail.CostumeID = item.CostumeID;
                    detail.CostumeName = costume.Name;
                    detail.ColorName = item.ColorName;
                    detail.Price = costume.Price;
                    detail.FAtm = item.F;
                    detail.SAtm = item.S;
                    detail.MAtm = item.M;
                    detail.LAtm = item.L;
                    detail.XSAtm = item.XS;
                    detail.XLAtm = item.XL;
                    detail.XL2Atm = item.XL2;
                    detail.XL3Atm = item.XL3;
                    detail.XL4Atm = item.XL4;
                    detail.XL5Atm = item.XL5;
                    detail.XL6Atm = item.XL6;
                }
                else
                {
                   // ShowErrorMessage("款号不存在：" + item.CostumeID);
                }
            }
        }

        private CheckStoreDetail ToCheckStoreDetailAtm(CostumeStoreHistory item)
        {
            CheckStoreDetail detail = new CheckStoreDetail();
            if (item != null)
            {
                Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
                if (costume != null)
                {
                    ReflectionHelper.CopyProperty(costume, detail);
                    detail.FAtm = item.F;
                    detail.SAtm = item.S;
                    detail.MAtm = item.M;
                    detail.LAtm = item.L;
                    detail.XSAtm = item.XS;
                    detail.XLAtm = item.XL;
                    detail.XL2Atm = item.XL2;
                    detail.XL3Atm = item.XL3;
                    detail.XL4Atm = item.XL4;
                    detail.XL5Atm = item.XL5;
                    detail.XL6Atm = item.XL6;
                    detail.ColorName = item.ColorName;
                    detail.CostumeName = costume.Name;
                }
                else
                {
                   // ShowErrorMessage("款号不存在：" + item.CostumeID);
                }
            }
            return detail;
        }

        private CheckStoreDetail ToCheckStoreDetail(CostumeStoreHistory item)
        {
            CheckStoreDetail detail = new CheckStoreDetail();
            if (item != null)
            {
                Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
                if (costume != null)
                { 
                    ReflectionHelper.CopyProperty(costume,detail);
                    detail.CostumeID = costume.ID; 
                    detail.CostumeName = costume.Name;
                    detail.ColorName = item.ColorName;
                    detail.BrandName = CommonGlobalCache.GetBrandName4CostumeID(detail.CostumeID);
                    detail.FAtm = item.F;
                    detail.SAtm = item.S;
                    detail.MAtm = item.M;
                    detail.LAtm = item.L;
                    detail.XSAtm = item.XS;
                    detail.XLAtm = item.XL;
                    detail.XL2Atm = item.XL2;
                    detail.XL3Atm = item.XL3;
                    detail.XL4Atm = item.XL4;
                    detail.XL5Atm = item.XL5;
                    detail.XL6Atm = item.XL6; 
                }
                else
                {
                   // ShowErrorMessage("款号不存在：" + item.CostumeID);
                }
            }
            return detail;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeData();
        }

        private void ShowDiff()
        {//显示盘点录入中有差异的商品
            List<CheckStoreDiff> diffList = new List<CheckStoreDiff>();

            foreach (var item in costumeStores)
            {
                if (!CheckBrand(item))
                {
                    continue;
                }
                CheckStoreDetail real = item;
                CostumeStoreHistory shot = shots.Find(t => t.CostumeID.ToUpper() == item.CostumeID.ToUpper() && item.ColorName == t.ColorName);
                if (shot == null)
                {
                    WebResponseObj<List<CostumeStoreHistory>> result =
                                    CommonGlobalCache.ServerProxy.GetCostumeStoreHistory4CheckStore(
                                    this.shopId, item.CostumeID,
                                    new Date(this.date), true
                                    );
                    if (result?.Data != null && result?.Data.Count > 0)
                    {
                        shot = result.Data.Find(t => t.CostumeID.ToUpper() == item.CostumeID.ToUpper() && item.ColorName == t.ColorName);
                    }
                }

                CheckStoreDetail quick = ToCheckStoreDetail(shot);
                CheckStoreDetail liaojian = new CheckStoreDetail();
                CheckStoreDetail diff = null;
                diff = SetCostumeStoreDiff(real, liaojian, quick, "差异");
                foreach (string sizeName in CostumeStoreHelper.CostumeSizeColumn)
                {
                    String dbSize = sizeName; //CostumeStoreHelper.GetCostumeSize(sizeName, sizeGroup); 
                    int differenceCount = Convert.ToInt32(CJBasic.Helpers.ReflectionHelper.GetProperty(diff, sizeName + "WinLost"));
                    if (differenceCount != 0)
                    {
                        int realcount = Convert.ToInt32(CJBasic.Helpers.ReflectionHelper.GetProperty(real, sizeName));
                        int changeCount = Convert.ToInt32(CJBasic.Helpers.ReflectionHelper.GetProperty(liaojian, sizeName));
                        int storeCount = Convert.ToInt32(CJBasic.Helpers.ReflectionHelper.GetProperty(quick, sizeName + "Atm"));

                        CheckStoreDiff storeDiff = new CheckStoreDiff();
                        ReflectionHelper.CopyProperty(real, storeDiff);
                        Costume costume = CommonGlobalCache.GetCostume(storeDiff.CostumeID);
                        String sizeDisplayName = CostumeStoreHelper.GetCostumeSizeName(sizeName, CommonGlobalCache.GetSizeGroup(costume.SizeGroupName));
                        storeDiff.SizeName = sizeDisplayName;
                        storeDiff.BrandName = CommonGlobalCache.GetBrandName(costume.BrandID);
                        storeDiff.DiffCount = differenceCount;
                        storeDiff.RealCount = realcount;
                        storeDiff.QuickCount = storeCount;
                        storeDiff.ChangeCount = changeCount;
                        diffList.Add(storeDiff);
                    }
                }
            }
            dataGridViewPagingSumCtrl2.BindingDataSource(diffList);
        }

        private void CheckTheSame()
        { //检查相同无差异款，根据盘点录入列表 


            List<CheckStoreDetail> noDiffList = new List<CheckStoreDetail>();


            foreach (var item in costumeStores)
            {
                CheckStoreDetail real = item;
                if (!CheckBrand(item))
                {
                    continue;
                }
                CostumeStoreHistory shot = shots.Find(t => t.CostumeID.ToUpper() == item.CostumeID.ToUpper() && item.ColorName == t.ColorName);
                if (shot == null)
                {  //读取已盘点单，并且与账面进行对比
                    WebResponseObj<List<CostumeStoreHistory>>
                   result =
                                    CommonGlobalCache.ServerProxy.GetCostumeStoreHistory4CheckStore(
                                    this.shopId, item.CostumeID,
                                    new Date(this.date), true
                                    );
                    if (result?.Data != null && result?.Data.Count > 0)
                    {
                        shot = result.Data.Find(t => t.CostumeID.ToUpper() == item.CostumeID.ToUpper() && item.ColorName == t.ColorName);
                    }
                    // shot = new CostumeStoreHistory();
                }

                CheckStoreDetail quick = ToCheckStoreDetail(shot);

                CheckStoreDetail liaojian = new CheckStoreDetail();
                CheckStoreDetail diff = null;
                diff = SetCostumeStoreDiff(real, liaojian, quick, "差异");
                if (diff.SumCountWinLost == 0)
                {
                    noDiffList.Add(real);
                }
            }
            
            dataGridViewPagingSumCtrl1.BindingDataSource(noDiffList);
            
            

        }
        private void ShowUnCheck()
        { 
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoShowUnCheck);
                cb.BeginInvoke(null, null);
                ShowProgressForm();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();
            }
        }

        private void DoShowUnCheck()
        {
            try
            {
                uncheckList = new List<CheckStoreDetail>();
                //不在列表中的款號
                InitProgress(shots.Count);
                int k = 0;
                foreach (CostumeStoreHistory item in shots)
                {
                    List<CheckStoreDetail> storeList = costumeStores.FindAll(t => t.CostumeID.ToUpper() == item.CostumeID.ToUpper() && t.ColorName == item.ColorName);
                    if (storeList == null || storeList.Count == 0)
                    {
                        int i = 0;
                         
                       UpdateProgress("正在加载");
                        
                        k++;
                        if (item != null)
                        {
                            CheckStoreDetail store = ToCheckStoreDetail(item);

                            //如果账面数为0不显示
                            if (store.HasNoDiffAtm)
                            {
                                continue;
                            }

                            if (!CheckBrand(store))
                            {
                                continue;
                            }

                            if (i == 0)
                            {
                                store.ShowSelected = true;
                            }
                            uncheckList.Add(store);
                        }
                        i++;
                    }
                    else
                    {
                        //已存在某款某颜色
                        int i = 0;

                        //同款的，只加入不同颜色的
                        //有对应颜色的话，不加入 
                        CheckStoreDetail store = storeList.Find(t => t.ColorName == item.ColorName);
                        if (store == null)
                        {
                            //不存在则添加
                            store = new CheckStoreDetail();
                            CJBasic.Helpers.ReflectionHelper.CopyProperty(item, store);
                            ToCheckStoreDetail(store, item);
                            //如果账面数为0不显示
                            if (store.HasNoDiffAtm)
                            {
                                continue;
                            }
                            if (!CheckBrand(store))
                            {
                                 continue;
                            }
                            Costume costume = CommonGlobalCache.GetCostume(store.CostumeID);
                            store.CostumeName = costume?.Name;
                            CJBasic.Helpers.ReflectionHelper.CopyProperty(costume, store);
                            if (i == 0) { store.ShowSelected = true; }
                            uncheckList.Add(store);
                            i++;
                        }
                    }
                }

                BindingSource(uncheckList);
            }
            catch (Exception ex)
            {
                FailedProgress(ex);
                ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();
            }
        }


        String brandID;
        private bool CheckBrand(CheckStoreDetail store)
        { 
            return store.BrandID == brandID || brandID=="-1";
        }

        private CheckStoreDetail SetCostumeStoreDiff(CheckStoreDetail real, CheckStoreDetail liaojian, CheckStoreDetail quick, string title)
        {
            if (quick == null)
            {
                return null;
            }
            CheckStoreDetail costumeStore = new CheckStoreDetail();

            CJBasic.Helpers.ReflectionHelper.CopyProperty(quick, costumeStore);
            // costumeStore.Title = title;
            //if (this.curUpdatedCheckStoreOrder == null)
            //{
            costumeStore.XS = (short)(real.XS + liaojian.XS - quick.XS);
            costumeStore.L = (short)(real.L + liaojian.L - quick.L);
            costumeStore.M = (short)(real.M + liaojian.M - quick.M);
            costumeStore.S = (short)(real.S + liaojian.S - quick.S);
            costumeStore.XL = (short)(real.XL + liaojian.XL - quick.XL);
            costumeStore.XL2 = (short)(real.XL2 + liaojian.XL2 - quick.XL2);
            costumeStore.XL3 = (short)(real.XL3 + liaojian.XL3 - quick.XL3);
            costumeStore.XL4 = (short)(real.XL4 + liaojian.XL4 - quick.XL4);
            costumeStore.XL5 = (short)(real.XL5 + liaojian.XL5 - quick.XL5);
            costumeStore.XL6 = (short)(real.XL6 + liaojian.XL6 - quick.XL6);
            costumeStore.F = (short)(real.F + liaojian.F - quick.F);
            //  }
            return costumeStore;
        }

        private void BindingSource(List<CheckStoreDetail> uncheckList)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<List<CheckStoreDetail>>(this.BindingSource), uncheckList);
            }
            else
            {
                dataGridViewPagingSumCtrl.BindingDataSource(uncheckList);
                CompleteProgressForm();
            }
        }

        private void BaseButton4_Click(object sender, EventArgs e)
        {

            //找出勾选的款项
            List<CheckStoreDetail> list = dataGridView1.DataSource as List<CheckStoreDetail>;
            List<CheckStoreDetail> uncheckList = list?.FindAll(t => t.Selected);
            if (uncheckList != null && uncheckList.Count > 0)
            {
                SameWithStoreClick?.Invoke(uncheckList, null);
                Reload();
            }
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            List<CheckStoreDetail> list = dataGridView1.DataSource as List<CheckStoreDetail>;
            List<CheckStoreDetail> uncheckList = list?.FindAll(t => t.Selected);
            try
            {  
            if (uncheckList != null && uncheckList.Count > 0)
            {
                ZeroClick?.Invoke(uncheckList, null);
                Reload();
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();
            }
        }

        internal void Reload()
        {
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void skinCheckBoxZone_CheckedChanged(object sender, EventArgs e)
        { 

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoSelected);
                cb.BeginInvoke(null, null);
                ShowProgressForm();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();
            }
        }

        private void DoSelected()
        {

            try
            { 
                InitProgress(dataGridView1.Rows.Count);
                SetChecked(); 
            }
            catch (Exception ex)
            {
                FailedProgress(ex);
                ShowError(ex);
            }
            finally
            {
                CompleteProgressForm();
                UnLockPage();
            }
        }

        private void SetChecked()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.SetChecked));
            }
            else
            {
                List<CheckStoreDetail> noDiffList = dataGridView1.DataSource as List<CheckStoreDetail>;
                int i = 0;
                foreach (var item in noDiffList)
                {
                   
                    UpdateProgress("正在加载");
                   i++;
                    item.Selected = skinCheckBoxZone.Checked;
                } 
                
                dataGridViewPagingSumCtrl1.BindingDataSource(noDiffList);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !view.Rows[e.RowIndex].IsNewRow)
                {
                    List<CheckStoreDetail> list = (List<CheckStoreDetail>)view.DataSource;
                    CheckStoreDetail item = (CheckStoreDetail)list[e.RowIndex];
                    switch (view.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText)
                    {
                        case "选择":
                            item.Selected = (bool)view[e.ColumnIndex, e.RowIndex].Value;
                            SetZoneSelected(item);
                            // SetSelectedTitle();
                            break;
                        default: break;
                    }
                }
            }
            catch

        (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void SetZoneSelected(CheckStoreDetail zone)
        {
            if (zone != null)
            {
                List<CheckStoreDetail> list = (List<CheckStoreDetail>)dataGridView1.DataSource;
                foreach (var item in list)
                {
                    if (zone.CostumeID.ToUpper() == item.CostumeID.ToUpper())
                    {
                        //
                        item.Selected = zone.Selected;
                    }
                }

                dataGridView1.Refresh();
            }

        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;

            }
            if (costumeIDDataGridViewTextBoxColumn.Index == e.ColumnIndex || costumeNameDataGridViewTextBoxColumn.Index == e.ColumnIndex)
            {
                //
                CheckStoreDetail store = dataGridView1.Rows[e.RowIndex].DataBoundItem as CheckStoreDetail;
                if (!store.ShowSelected)
                {
                    e.Value = null;
                }
            }
        }

        private void baseButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckStoreCompareForm_Load(object sender, EventArgs e)
        {
            if (shots == null)
            {
                //读取已盘点单，并且与账面进行对比
                WebResponseObj<List<CostumeStoreHistory>> result = CommonGlobalCache.ServerProxy.GetCostumeStoreHistory4CheckStore(
                                this.shopId, null,
                                new Date(this.date), false
                                );
                if (result?.Data != null)
                {
                    shots = result.Data;
                }
            }
        }

        private void CheckStoreCompareForm_Shown(object sender, EventArgs e)
        {
            Initialize();
        }

        private void skinComboBox_Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            brandID = ValidateUtil.CheckEmptyValue(skinComboBox_Brand.SelectedValue);
            
        }

        private void ChangeData()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    ShowUnCheck();
                    break;
                case 1:
                    CheckTheSame();
                    break;
                case 2:
                    ShowDiff();
                    break;
                default:
                    break;
            }
        }

        private void BaseButtonConfirm_Click(object sender, EventArgs e)
        {
            ChangeData();
        }
    }
}
