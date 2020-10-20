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
    public partial class ShopComboBox : SkinComboBox
    {
        private bool initialized = false;
        public bool Initialized { get => initialized; }

        public new EventHandler SelectedIndexChanged;
        public ShopComboBox()
        {
            InitializeComponent();
            this.Width = 80;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            base.SelectedIndexChanged += GuideComboBox_SelectedIndexChanged;
        }

        private void GuideComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// 初始化ComboBox
        /// </summary>
        /// <param name="GuideComboBoxInitializeType">初始化下来列表加入选择类型</param>
        public void Initialize(Boolean hideAll = false, Boolean excludeGeneralStoreShop = false, Boolean showOnline = false, Boolean emptyOnline = false,string shopId=null)
        {
            //加入正常状态的导购到下拉列表中
            CommonGlobalUtil.SetShop(this, hideAll, excludeGeneralStoreShop, showOnline, emptyOnline,shopId);
            this.initialized = true;
        }
    }
}
