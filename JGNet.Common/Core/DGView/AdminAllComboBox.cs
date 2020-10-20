using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;

namespace JGNet.Common
{
    public partial class AdminAllComboBox : SkinComboBox
    { 

        public AdminAllComboBox()
        {
            InitializeComponent();
            this.Width = 120;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndexChanged += GuideComboBox_SelectedIndexChanged;

        }

        private void GuideComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdminUser guide = (AdminUser)base.SelectedItem;
        }


        /// <summary>
        /// 初始化ComboBox
        /// </summary>
        /// <param name="GuideComboBoxInitializeType">初始化下来列表加入选择类型</param>
        public void Initialize()
        { 
            List<AdminUser> guideList = CommonGlobalCache.AdminUserList.FindAll(t=>t.State == 0 ); 
            this.DisplayMember = "Name";
            this.ValueMember = "ID";
            this.DataSource = guideList; 
        }
    } 
}
