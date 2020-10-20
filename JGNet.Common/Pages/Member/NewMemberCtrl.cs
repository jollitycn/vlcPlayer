using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin;
using CJBasic.Loggers;
using System.Text.RegularExpressions;
using JGNet.Common.Core;
using JGNet.Common;
using JGNet.Common.Core.Util;
using CJBasic.Security;
using JGNet.Core.Const;
using System.IO;
using CCWin.SkinControl;
using JGNet.Core.InteractEntity;

namespace JGNet.Common
{
    public partial class NewMemberCtrl : BaseModifyUserControl
    {
        private Member _member;
        public NewMemberCtrl(Member member)
        {
            InitializeComponent();
            if (member != null)
            {
                this._member = member;
                this.skinTextBox_ID.Enabled = false;
                this.skinTextBox_IntroducerID.Enabled = false;
            }
            this.Initialize();

        }
        public NewMemberCtrl()
        {
            InitializeComponent();
            this.Initialize();
        }

        private void Initialize()
        {
            MenuPermission =  RolePermissionMenuEnum.会员管理;
            this.skinTextBox_IntroducerID.CheckMember = true;
            List<ListItem<byte>> sourceList = new List<ListItem<byte>>();
            sourceList.Add(new ListItem<byte>(CommonGlobalUtil.COMBOBOX_NULL, 0));
            sourceList.Add(new ListItem<byte>("网上", 1));
            sourceList.Add(new ListItem<byte>("熟人介绍", 2));
            sourceList.Add(new ListItem<byte>("传单", 3));
            sourceList.Add(new ListItem<byte>("广告", 4));
            this.skinComboBox_Source.DataSource = sourceList;
            this.skinComboBox_Source.DisplayMember = "Key";
            this.skinComboBox_Source.ValueMember = "Value";
            this.skinComboBox_Source.SelectedIndex = 0;
            textBoxUserName.Visible = false;
            textBoxUserName.Enabled = false;
                this.guideComboBox1.Initialize(GuideComboBoxInitializeType.MemberGuid, CommonGlobalCache.CurrentShopID);
            textBoxUserName.Text = this.guideComboBox1.SelectedText;
            
            this.SetForm4MemberValue();
        }

        internal void DisplayMember(Member member)
        {
            this._member = member;
            this.skinTextBox_ID.ReadOnly = true;
            this.skinTextBox_Name.ReadOnly = true;
            this.skinTextBox_WeiXin.Enabled = false;
            this.skinComboBox_Source.Enabled = false;
            this.skinTextBox_IntroducerID.Enabled = false;
            skinRadioButton1.Enabled = false;
            skinRadioButton2.Enabled = false;
            this.dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
            this.skinTextBox_Remark.Enabled = false;
            textBoxDetailAddress.Enabled = false;
            dateTimePickerCreateTime.Value = DateTime.Now;
            skinComboBoxShop.SelectedValue = CommonGlobalCache.CurrentShopID;
            this.BaseButton1.Visible = false;
            SetForm4MemberValue(true);
            // this.Show();
        }

        private void SetForm4MemberValue(bool isDetail = false)
        {
            if (_member == null)
            {
                skinComboBoxShop.Initialize(true);
                this.skinTextBox_ID.Text = String.Empty;
                this.skinTextBox_Name.Text = String.Empty;
                this.skinTextBox_WeiXin.Text = String.Empty;
                this.skinComboBox_Source.SelectedIndex = 0;
                this.skinTextBox_IntroducerID.Text = String.Empty;
                this.skinRadioButton1.Checked = true;
                this.txttel.Text = String.Empty;
                this.dateTimePicker1.Value = DateTime.Now;
                this.skinTextBox_Remark.Text = String.Empty;
                textBoxDetailAddress.Text = String.Empty;
                dateTimePickerCreateTime.Value = DateTime.Now;
                skinComboBoxShop.SelectedValue = CommonGlobalCache.CurrentShopID; 
                this.skinTextBox_CurrentIntegration.Text = String.Empty;

                if (CommonGlobalCache.CurrentUser.Type == UserInfoType.Guide)
                {
                    this.guideComboBox1.SelectedValue = CommonGlobalCache.CurrentUserID;
                }

            }
            else
            {
                skinLabel_Operator.Visible = true;
                this.skinTextBox_ID.Text = this._member.PhoneNumber;
                this.skinTextBox_Name.Text = this._member.Name;
                this.skinTextBox_WeiXin.Text = this._member.WeiXin;
                skinComboBox_Source.Visible = false;
                this.skinComboBox_Source.SelectedValue = this._member.Source;
                skinComboBox_Source.Visible = true;
                this.skinTextBox_IntroducerID.Text = this._member.IntroducerID;
                this.skinRadioButton1.Checked = this._member.Sex;
                this.skinRadioButton2.Checked = !this._member.Sex;
                this.txttel.Text = this._member.Phone;
                this.dateTimePicker1.Value = this._member.Birthday;
                this.skinTextBox_Remark.Text = this._member.Remarks;
                this.skinTextBox_CurrentIntegration.Text = this._member.CurrentIntegration.ToString();
                textBoxDetailAddress.Text = this._member.DetailAddress;
                dateTimePickerCreateTime.Value = this._member.CreatedTime;
            //    this.guideComboBox1.SelectedValue = this._member.GuideID;
                if (String.IsNullOrEmpty(this._member.ShopID))
                {
                  //  SetOnlineShop(skinComboBoxShop);

                    skinComboBoxShop.Initialize(true,false,true);
                    skinComboBoxShop.SelectedValue = SystemDefault.Report_Online;
                }
                else
                {
                    skinComboBoxShop.Initialize(true);
                    skinComboBoxShop.SelectedValue = this._member.ShopID;
                }

                skinComboBoxShop.Visible = true;
                // skinComboBoxShop.Refresh();
                //编辑的不能更改导购员了，以后只显示用
               // guideComboBox1.SelectedValue = this._member.GuideID;
                textBoxUserName.Visible = false;
                textBoxUserName.Enabled = false;
                textBoxUserName.Text = CommonGlobalCache.GetUserName(this._member.GuideID);
                guideComboBox1.Initialize(GuideComboBoxInitializeType.MemberGuid, ValidateUtil.CheckEmptyValue(this.skinComboBoxShop.SelectedValue));
                this.guideComboBox1.SelectedValue = this._member.GuideID;
                LoadPic();
            }

        }

        //private void SetOnlineShop(SkinComboBox skinComboBoxShopID)
        //{
        //    List<Shop> list = new List<Shop>();
        //    list.Add(new Shop() { Name = SystemDefault.onlineName, ID = SystemDefault.Report_Online, Enabled = true });
        //    skinComboBoxShopID.DisplayMember = "Name";
        //    skinComboBoxShopID.ValueMember = "ID";
        //    skinComboBoxShopID.DataSource = list;
        //}

        private Byte[] photo { get; set; }
        private void LoadPic()
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                //photo = CommonGlobalCache.ServerProxy.GetMemberHeadImage(this._member.PhoneNumber);
                //if (photo != null)
                //{
                  //  MemoryStream stream = new MemoryStream(photo);
                //Image image = new Bitmap(stream); 
                if (_member.HeadImageUrl != null && _member.HeadImageUrl!="")
                {
                    Image image = Image.FromStream(System.Net.WebRequest.Create(_member.HeadImageUrl).GetResponse().GetResponseStream());
                    this.pictureBoxHeaderImage.Image = image;
                }
                else
                {
                    this.pictureBoxHeaderImage.Image = null;
                }
                //}
                //else
                //{
                //    this.pictureBoxHeaderImage.Image = null;
                //}
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
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                string MemId = this.skinTextBox_ID.Text;
                if (string.IsNullOrEmpty(MemId))
                {
                    GlobalMessageBox.Show("卡号不能为空!");
                    return;
                }
                //^[0-9A-Za-z_]+$
                string matchID = "^[0-9A-Za-z]+$";
                bool isMemberID = Regex.IsMatch(MemId, matchID);
                if (!isMemberID)
                {
                    GlobalMessageBox.Show("卡号格式不正确，卡号只能含数字或英文字母!");
                    return;
                }

                string phoneNumber = this.txttel.Text;
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    GlobalMessageBox.Show("手机号不能为空!");
                    return;
                }

                string match = "^((1[3,5,8][0-9])|(14[5,7])|(17[0,6,7,8])|(19[7]))\\d{8}$";
                bool isPhoneNumber = Regex.IsMatch(phoneNumber, match);
                if (!isPhoneNumber)
                {
                    GlobalMessageBox.Show("手机号码格式不正确!");
                    return;
                }
                string name = this.skinTextBox_Name.Text;
                if (string.IsNullOrEmpty(name))
                {
                    GlobalMessageBox.Show("姓名不能为空!");
                    return;
                }
                //if (!isOnline && (String.IsNullOrEmpty(this.guideID) || "-1".Equals(this.guideID)))
                //{
                //    GlobalMessageBox.Show("操作人不能为空!");
                //    return;
                //}
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                //string cintegration = this.skinTextBox_CurrentIntegration.Text;
                if (this._member != null)
                {
                    UpdateMemberResult result = this.UpdateMember();
                    if (result == UpdateMemberResult.Error)
                    {
                        GlobalMessageBox.Show("内部错误!");
                    }
                    else if (result == UpdateMemberResult.IsNotExist)
                    {
                        GlobalMessageBox.Show("会员卡号不存在！");
                    }
                    else if (result == UpdateMemberResult.Success)
                    {
                        TreeModel treeN = new TreeModel();
                        treeN.ID = _member.PhoneNumber;
                        treeN.Name = _member.Name;
                        CommonGlobalCache.UpdateDistributor(treeN);
                        GlobalMessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK);
                        this.TabPageClose(this.CurrentTabPage, this.SourceCtrlType);

                    }
                }
                else
                {

                    InteractResult result = this.AddMember();
                    if (result.ExeResult == ExeResult.Success)
                    {
                        //TreeModel treeN = new TreeModel();
                        //treeN.ID = member.PhoneNumber;
                        //treeN.ParentID = member.IntroducerName;
                        //treeN.Name = member.Name;
                        //CommonGlobalCache.InsertDistributor(treeN);
                        CommonGlobalCache.DistributorList.Clear();
                        GlobalMessageBox.Show("开卡成功！", "提示", MessageBoxButtons.OK);
                        // member
                        this.TabPageClose(this.CurrentTabPage, this.SourceCtrlType);
                         

                    }
                    else
                    {
                        GlobalMessageBox.Show(result.Msg);
                    }
                    //if (result == RegisterMemberResult.Error)
                    //{
                    //    GlobalMessageBox.Show("内部错误!");
                    //}
                    //else if (result == RegisterMemberResult.Exist)
                    //{
                    //    GlobalMessageBox.Show("会员卡号已存在！");
                    //}
                    //else if (result == RegisterMemberResult.Success)
                    //{
                    //    GlobalMessageBox.Show("开卡成功！", "提示", MessageBoxButtons.OK);
                    //    this.TabPageClose(this.CurrentTabPage, this);

                    //}
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

        private UpdateMemberResult UpdateMember()
        {
            this._member.Name = this.skinTextBox_Name.Text;
            this._member.WeiXin = this.skinTextBox_WeiXin.Text;
            //  this._member.CardType = (byte)this.skinComboBox_CardType.SelectedValue;
            this._member.Source = (byte)this.skinComboBox_Source.SelectedValue;
            this._member.IntroducerID = this.skinTextBox_IntroducerID.Text;
            this._member.Phone = this.txttel.Text;
            this._member.Sex = this.skinRadioButton1.Checked;
            this._member.Birthday = this.dateTimePicker1.Value;
            this._member.Remarks = this.skinTextBox_Remark.Text;
            this._member.DetailAddress = textBoxDetailAddress.Text;
            this._member.GuideID = (string)this.guideComboBox1.SelectedValue;
            this._member.ShopID = (string)this.skinComboBoxShop.SelectedValue;
            this._member.CurrentIntegration = Convert.ToInt32(this.skinTextBox_CurrentIntegration.Text);
            _member.DetailAddress = textBoxDetailAddress.Text;
            this._member.CreatedTime = this.dateTimePickerCreateTime.Value;

            //   this._member.State =  (byte)(skinCheckBox_state.Checked?1:0);
            return CommonGlobalCache.ServerProxy.UpdateMember(this._member);
        }
        Member member;
        private InteractResult AddMember()
        {
             member = new Member()
            {

                PhoneNumber = this.skinTextBox_ID.Text.ToLower(),
                Name = this.skinTextBox_Name.Text,
                WeiXin = this.skinTextBox_WeiXin.Text,
                Password = SecurityHelper.MD5String2(SystemDefault.Pwd),
                // CardType = (byte)this.skinComboBox_CardType.SelectedValue,
                Source = (byte)this.skinComboBox_Source.SelectedValue,
                IntroducerID = this.skinTextBox_IntroducerID.Text,
                Sex = this.skinRadioButton1.Checked,
                Phone = this.txttel.Text,
                Birthday = this.dateTimePicker1.Value,
                Remarks = this.skinTextBox_Remark.Text,
                ShopID = ValidateUtil.CheckEmptyValue(skinComboBoxShop.SelectedValue),
                CreatedTime = dateTimePickerCreateTime.Value,
                GuideID = (string)this.guideComboBox1.SelectedValue.ToString(),
                CurrentIntegration = Convert.ToInt32(String.IsNullOrEmpty(this.skinTextBox_CurrentIntegration.Text) ? "0" : this.skinTextBox_CurrentIntegration.Text),
                DetailAddress = textBoxDetailAddress.Text,
                State = 1//(byte)(skinCheckBox_state.Checked ? 1 : 0)
            };
            return CommonGlobalCache.ServerProxy.RegisterMember(member);
        }

        private void skinTextBox_CurrentIntegration_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int tmp = int.Parse(skinTextBox_CurrentIntegration.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请正确输入当前积分！");
                e.Cancel = true;
                skinTextBox_CurrentIntegration.Text = "0";
                return;
            }
        }

        private void skinComboBoxShop_SelectedValueChanged(object sender, EventArgs e)
        {
            //根据开卡店铺获取导购员信息
            if (this.skinComboBoxShop != null && this.skinComboBoxShop.Items.Count > 0)
            {
                if (this.skinComboBoxShop.SelectedValue != null && this.skinComboBoxShop.SelectedValue.ToString() != "") {
                    this.guideComboBox1.Initialize(GuideComboBoxInitializeType.MemberGuid, this.skinComboBoxShop.SelectedValue.ToString());
                }
            }
        }
    }
}