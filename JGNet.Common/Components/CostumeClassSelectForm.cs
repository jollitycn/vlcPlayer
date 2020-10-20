
using CCWin;
using JGNet.Common;
using JGNet.Common.cache.Wholesale;
using JGNet.Common.Components; 
using CJBasic.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class CostumeClassSelectForm : BaseForm
    {
        /// <summary>
        /// 会员被选择时触发
        /// </summary>
        public event CJBasic.Action<TreeNode, EventArgs> ItemSelected;

        public CostumeClassSelectForm( )
        {
            InitializeComponent();
            skinTreeViewClass.Nodes.AddRange(CostumeClassUtil.GetTreeNodes().ToArray());
        }

        //提交选择的会员
        private void ConfirmSelectCell(TreeNode node)
        {
            if (this.ItemSelected != null)
            {
                this.ItemSelected(node, null);
            }
            this.DialogResult = DialogResult.OK;
        }

        //点击确认按钮
        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (skinTreeViewClass != null && skinTreeViewClass.SelectedNode != null)
                {
                    this.ConfirmSelectCell(skinTreeViewClass.SelectedNode);
                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        //点击取消按钮
        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void skinTreeViewClass_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BaseButton_OK_Click(null, null);
        }
    }
}
