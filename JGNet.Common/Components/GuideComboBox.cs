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
    public partial class GuideComboBox : SkinComboBox
    {
        private bool initialized = false;
        public bool Initialized { get => initialized; } 

        public GuideComboBox()
        {
            InitializeComponent();
            this.Width = 80;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndexChanged += GuideComboBox_SelectedIndexChanged;
        }

        private void GuideComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guide guide = (Guide)base.SelectedItem;
        }

        /// <summary>
        /// 初始化ComboBox
        /// </summary>
        /// <param name="GuideComboBoxInitializeType">初始化下来列表加入选择类型</param>
        public void Initialize(GuideComboBoxInitializeType type, String shopID = null)
        {
            //加入正常状态的导购到下拉列表中
            this.ShopID = shopID;
            List<Guide> guideList = CommonGlobalCache.GuideList.FindAll(t=>t.State == 0 ); 

            if (!String.IsNullOrEmpty(ShopID))
            {
                guideList = guideList.FindAll(t => t.ShopID == ShopID);
            } 
            if (type == GuideComboBoxInitializeType.Null)
            {
                guideList.Insert(0, new Guide() { Name = CommonGlobalUtil.COMBOBOX_NULL, ID = "-1" });
            }
            if (type == GuideComboBoxInitializeType.MemberGuid)
            {
                guideList.Insert(0, new Guide() { Name = CommonGlobalUtil.COMBOBOX_NULL, ID = "" });
            }
            else if (type == GuideComboBoxInitializeType.All)
            {
                guideList.Insert(0, new Guide() { Name = CommonGlobalUtil.COMBOBOX_ALL, ID = null });
            }

            this.DisplayMember = "Name";
            this.ValueMember = "ID";
            this.DataSource = guideList;
            this.initialized = true;
        }

        public String ShopID { get; set; }
         
    }

    /// <summary>
    /// GuideComboBox 初始化类型
    /// </summary>
    public enum GuideComboBoxInitializeType
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,

        /// <summary>
        /// 无
        /// </summary>
        Null,
        /// <summary>
        /// 所有
        /// </summary>
        All,
        /// <summary>
        /// 没有开卡人
        /// </summary>
        MemberGuid

    }
 

     
}
