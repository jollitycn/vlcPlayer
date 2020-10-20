using CCWin.SkinControl;
using JGNet.Common.Components;
using System.Windows.Forms;

namespace JGNet.Common
{
    partial class CostumeClassSelectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CostumeClassSelectForm));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinTreeViewClass = new CCWin.SkinControl.SkinTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.skinPanel3 = new CCWin.SkinControl.SkinPanel();
            this.BaseButton2 = new JGNet.Common.Components.BaseButton();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.PfCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel1.SuspendLayout();
            this.skinPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PfCustomerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.skinTreeViewClass);
            this.skinPanel1.Controls.Add(this.skinPanel3);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 28);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(256, 380);
            this.skinPanel1.TabIndex = 0;
            // 
            // skinTreeViewClass
            // 
            this.skinTreeViewClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTreeViewClass.ImageIndex = 0;
            this.skinTreeViewClass.ImageList = this.imageList1;
            this.skinTreeViewClass.Indent = 25;
            this.skinTreeViewClass.ItemHeight = 25;
            this.skinTreeViewClass.Location = new System.Drawing.Point(0, 0);
            this.skinTreeViewClass.Name = "skinTreeViewClass";
            this.skinTreeViewClass.PathSeparator = ".";
            this.skinTreeViewClass.SelectedImageIndex = 0;
            this.skinTreeViewClass.Size = new System.Drawing.Size(256, 342);
            this.skinTreeViewClass.TabIndex = 76;
            this.skinTreeViewClass.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.skinTreeViewClass_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "红.png");
            this.imageList1.Images.SetKeyName(1, "绿.png");
            this.imageList1.Images.SetKeyName(2, "黄.png");
            this.imageList1.Images.SetKeyName(3, "蓝.png");
            // 
            // skinPanel3
            // 
            this.skinPanel3.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel3.Controls.Add(this.BaseButton2);
            this.skinPanel3.Controls.Add(this.BaseButton1);
            this.skinPanel3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPanel3.DownBack = null;
            this.skinPanel3.Location = new System.Drawing.Point(0, 342);
            this.skinPanel3.MouseBack = null;
            this.skinPanel3.Name = "skinPanel3";
            this.skinPanel3.NormlBack = null;
            this.skinPanel3.Size = new System.Drawing.Size(256, 38);
            this.skinPanel3.TabIndex = 2;
            // 
            // BaseButton2
            // 
            this.BaseButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton2.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton2.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton2.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton2.Location = new System.Drawing.Point(94, 6);
            this.BaseButton2.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton2.Name = "BaseButton2";
            this.BaseButton2.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton2.Size = new System.Drawing.Size(75, 32);
            this.BaseButton2.TabIndex = 3;
            this.BaseButton2.Text = "确定";
            this.BaseButton2.UseVisualStyleBackColor = false;
            this.BaseButton2.Click += new System.EventHandler(this.BaseButton_OK_Click);
            // 
            // BaseButton1
            // 
            this.BaseButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(175, 6);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 4;
            this.BaseButton1.Text = "关闭";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Quit_Click);
            // 
            // PfCustomerBindingSource
            // 
            this.PfCustomerBindingSource.DataSource = typeof(JGNet.PfCustomer);
            // 
            // CostumeClassSelectForm
            // 
            this.AcceptButton = this.BaseButton2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 412);
            this.Controls.Add(this.skinPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CostumeClassSelectForm";
            this.Text = "选择类别";
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PfCustomerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanel skinPanel1;
        private SkinPanel skinPanel3;
        private Common.Components.BaseButton BaseButton2;
        private Common.Components.BaseButton BaseButton1;
        private BindingSource PfCustomerBindingSource;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sexNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn guideNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn weiXinDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn detailAddressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentIntegrationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn accruedIntegrationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn accruedSpendDataGridViewTextBoxColumn;
        private SkinTreeView skinTreeViewClass;
        private ImageList imageList1;
    }
}