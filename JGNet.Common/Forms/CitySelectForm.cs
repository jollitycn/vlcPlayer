
using CCWin;
using JGNet.Common.Components;
using JGNet.Common.Models;
using CJBasic.Loggers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class CitySelectForm : BaseForm
    {


        private List<Zone> resultList;//当前被绑定的源
        private List<Zone> editedList;
        /// <summary>
        /// 会员被选择时触发
        /// </summary>
        public event CJBasic.Action<List<Zone>, EventArgs> ReturnSelected;

        public CitySelectForm(List<Zone> para)
        {
            InitializeComponent();






            editedList = para;

        }

        //点击按钮查询
        private void BaseButton1_Click(object sender, EventArgs e)
        {
            try
            {


                //string memberID = this.skinTextBox1.SkinTxt.Text.Trim();
                // if (string.IsNullOrEmpty(memberID))
                // {
                //     return;
                // }
                // if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                // this.resultList = CommonGlobalCache.ServerProxy.GetMembers4PhoneNumber(memberID);
                // this.BindingDataSource();
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.WriteLog(ee);
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }

        //绑定数据源
        private void BindingDataSource()
        {
            //if (this.resultList != null && this.resultList.Count != 0)
            //{
            //    foreach (Member member in this.resultList)
            //    {
            //        member.GuideName = CommonGlobalCache.GetUserName(member.GuideID);
            //    }
            //}
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.resultList;
            SetUnabled(dataGridView1);
        }

        //双击单元格
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            this.ConfirmSelectCell(this.resultList);
        }

        //提交选择的会员
        private void ConfirmSelectCell(List<Zone> result)
        {
            if (this.ReturnSelected != null)
            {
                this.ReturnSelected(result, null);
            }
            this.DialogResult = DialogResult.OK;
        }

        //点击确认按钮
        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.DataSource == null)
                {
                    return;
                }
                this.ConfirmSelectCell(this.resultList);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.WriteLog(ee);
                GlobalMessageBox.Show("确认失败！");
            }
        }

        //点击取消按钮
        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    this.ConfirmSelectCell(this.resultList);
        //}


        Zone curZone;
        Province curProvince;

        public List<Zone> UnabledZones { get; set; }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //重新载入省份   
            try
            {

                Zone zone = (Zone)this.dataGridView1.CurrentRow.DataBoundItem;
                if (zone != null && zone != curZone)
                {
                    this.dataGridView2.DataSource = null;
                    this.dataGridView2.DataSource = zone.Province;
                    SetUnabled(dataGridView2);
                    curZone = zone;
                    //取消全选状态

                    skinCheckBoxProvince.Checked = false;
                    skinCheckBoxCity.Checked = false;

                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                DataGridView view = (DataGridView)sender;
                Province province = (Province)view.CurrentRow.DataBoundItem;
                if (province != null && province != curProvince)
                {
                    this.dataGridView3.DataSource = null;
                    this.dataGridView3.DataSource = province.Sub;
                    SetUnabled(dataGridView3);
                    curProvince = province;
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }


        private void SetZoneSelected(Zone zone)
        {
            if (zone != null)
            {
                foreach (var province in zone.Province)
                {

                    if (province.Enabled)
                    {
                        province.Selected = zone.Selected;
                        this.skinCheckBoxProvince.Checked = province.Selected;
                        foreach (var city in province.Sub)
                        {
                            if (city.Enabled)
                            {
                                city.Selected = zone.Selected;
                                this.skinCheckBoxCity.Checked = province.Selected;
                            }
                        }
                    }
                }
                curProvince = null;

                //  this.dataGridView2.DataSource = null;
                //  this.dataGridView2.DataSource = zone.Province;

                //  SetUnabled(dataGridView2);
                dataGridView2.Refresh();
            }

        }
        private void SetProvinceSelected(Province province)
        {
            if (province != null)
            {
                foreach (var city in province.Sub)
                {
                    if (city.Enabled)
                    {
                        city.Selected = province.Selected;
                        this.skinCheckBoxCity.Checked = province.Selected;
                    }
                }
                dataGridView3.Refresh();
               // this.dataGridView3.DataSource = null;
               // this.dataGridView3.DataSource = province.Sub;
               //  SetUnabled(dataGridView3);
            }
        }

        private void SetSelectedTitle()
        { //检查所有
            CarriageCost cost = CarriageCostUtil.ZoneToCarriageCost(resultList);
            skinLabelAreaStr.Text = cost.AreaStr;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !view.Rows[e.RowIndex].IsNewRow)
                {
                    List<Zone> list = (List<Zone>)view.DataSource;
                    Zone item = (Zone)list[e.RowIndex];
                    switch (view.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText)
                    {
                        case "选择":
                            item.Selected = (bool)view[e.ColumnIndex, e.RowIndex].Value;
                            SetZoneSelected(item);
                            SetSelectedTitle();
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
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !view.Rows[e.RowIndex].IsNewRow)
                {
                    List<Province> list = (List<Province>)view.DataSource;
                    Province item = (Province)list[e.RowIndex];
                    switch (view.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText)
                    {
                        case "选择":
                            item.Selected = (bool)view[e.ColumnIndex, e.RowIndex].Value;
                            //  CheckProvince();
                            SetProvinceSelected(item);
                            CheckZone();
                            SetSelectedTitle();
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
        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !view.Rows[e.RowIndex].IsNewRow)
                {
                    List<City> list = (List<City>)view.DataSource;
                    City item = (City)list[e.RowIndex];
                    switch (view.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText)
                    {
                        case "选择":
                            item.Selected = (bool)view[e.ColumnIndex, e.RowIndex].Value;
                            CheckProvince();
                            SetSelectedTitle();
                            break;
                        default: break;
                    }
                }
            }
            catch (Exception ex)
            {
              //  CommonGlobalUtil.ShowError(ex);
            }
        }

        private void CheckProvince()
        {

            dataGridView2.CellValueChanged -= dataGridView2_CellValueChanged;

            if (curProvince != null)
            {
                dataGridView2.CurrentRow.Cells[0].Value = false;
                curProvince.Selected = false;

                foreach (DataGridViewRow item in dataGridView3.Rows)
                {
                    if ((bool)item.Cells[0].Value)
                    {
                        if (!dataGridView2.CurrentRow.Cells[0].ReadOnly)
                        {
                            dataGridView2.CurrentRow.Cells[0].Value = true;
                        }
                        break;
                    }
                     
                } 
                //foreach (var item in curProvince.Sub)
                //{
                //    //全选，但是绑定的数据没有关联还是SELECTED
                //    if (item.Selected)
                //    {
                        
                //    }
                //}
            }
            dataGridView2.CellValueChanged += dataGridView2_CellValueChanged;
            CheckZone();
            //     dataGridView2_CellValueChanged(dataGridView2, new DataGridViewCellEventArgs(0, dataGridView2.CurrentRow.Index));

            //this.dataGridView2.DataSource = null;
            //this.dataGridView2.DataSource = curZone.Province;
        }


        private void CheckZone()
        {
            dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            if (curZone != null)
            {
                dataGridView1.CurrentRow.Cells[0].Value = false;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        if (!dataGridView1.CurrentRow.Cells[0].ReadOnly)
                        {
                            dataGridView1.CurrentRow.Cells[0].Value = true;
                        }
                        break;
                    }
                }
            }
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void CitySelectForm_Load(object sender, EventArgs e)
        {
            try
            {
                string jsonText = File.ReadAllText(@"CitySelectForm.dat");
                resultList = (List<Zone>)JavaScriptConvert.DeserializeObject(jsonText, typeof(List<Zone>));
                CheckSelected();
                CheckUnabledZones();
                BindingDataSource();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void CheckUnabledZones()
        {
            if (UnabledZones != null)
            {
                foreach (Zone z in resultList)
                {
                    foreach (Province p in z.Province)
                    {
                        foreach (Zone ze in UnabledZones)
                        {
                            foreach (Province pe in ze.Province)
                            {
                                if (p.Name == pe.Name)
                                {

                                    if (pe.Sub != null)
                                    {

                                        foreach (var ce in pe.Sub)
                                        {
                                            foreach (var c in p.Sub)
                                            {
                                                if (c.Name == ce.Name)
                                                {
                                                    c.Enabled = false;
                                                }
                                            }
                                        }
                                        p.Enabled = p.Sub.Exists(t => t.Enabled);
                                    }
                                    else
                                    {
                                        p.Enabled = false;
                                        p.Sub.ForEach(t => t.Enabled = false);
                                    }
                                }
                            }
                        }

                    }
                    z.Enabled = z.Province.Exists(t => t.Enabled);
                }
            }
        }

        private void CheckSelected()
        {
            if (editedList != null)
            {
                foreach (Zone z in resultList)
                {
                    foreach (Province p in z.Province)
                    {
                        foreach (Zone ze in editedList)
                        {
                            foreach (Province pe in ze.Province)
                            {
                                if (p.Name == pe.Name)
                                {
                                    p.Selected = pe.Selected;
                                    if (pe.Sub != null)
                                    {
                                        foreach (var ce in pe.Sub)
                                        {
                                            foreach (var c in p.Sub)
                                            {

                                                if (c.Name == ce.Name)
                                                {
                                                    c.Selected = ce.Selected;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {

                                        foreach (var c in p.Sub)
                                        {
                                            c.Selected = true;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }


        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView2.IsCurrentCellDirty)
            {
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView3_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView3.IsCurrentCellDirty)
            {
                dataGridView3.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }
        private void SetUnabled(DataGridView view)
        {
            foreach (DataGridViewRow row in view.Rows)
            {
                if (row.DataBoundItem is Zone)
                {
                    Zone item = (Zone)row.DataBoundItem;
                    if (!item.Enabled)
                    {
                        SetUnabled(row);
                    }
                }
                else
                if (row.DataBoundItem is Province)
                {
                    Province item = (Province)row.DataBoundItem;
                    if (!item.Enabled)
                    {
                        SetUnabled(row);
                    }
                }
                else
                if (row.DataBoundItem is City)
                {
                    City item = (City)row.DataBoundItem;
                    if (!item.Enabled)
                    {
                        SetUnabled(row);
                    }
                }
            }

        }

        private void SetUnabled(DataGridViewRow row)
        {
            row.ReadOnly = true;
            row.DefaultCellStyle.ApplyStyle(new DataGridViewCellStyle()
            {
                BackColor = Color.Gainsboro
            });
        }


        private void skinCheckBoxZone_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.Cells[0].Value = skinCheckBoxZone.Checked;
            }
            //List<Zone> resultList = dataGridView1.DataSource as List<Zone>;
            //foreach (var item in resultList)
            //{
            //    item.Selected = skinCheckBoxZone.Checked;
            //    skinCheckBoxProvince.Checked = skinCheckBoxZone.Checked;
            //}
            //dataGridView1.DataSource = null;
            //dataGridView1.DataSource = resultList;


        }

        private void skinCheckBoxProvince_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                Province pro = item.DataBoundItem as Province;
                if (pro.Enabled)
                {
                    item.Cells[0].Value = skinCheckBoxProvince.Checked;
                }
                else
                {
                    item.Cells[0].Value = false;
                }
            }
         //   DataGridViewRow row = dataGridView2.CurrentRow;
           // dataGridView2_SelectionChanged(dataGridView2, null);
           // curProvince = null;
          //  row.Selected = true;



        }

        private void skinCheckBoxCity_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView3.Rows)
            {
                City pro = item.DataBoundItem as City;
                if (pro.Enabled)
                {
                    item.Cells[0].Value = skinCheckBoxCity.Checked;
                }
                else
                {
                    item.Cells[0].Value = false;
                }
            } 
        }

    }
}
