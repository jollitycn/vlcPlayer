namespace JGNet.Common.Components
{
    partial class SupllierComboBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.skinComboBox = new CCWin.SkinControl.SkinComboBox();
            this.skinLabelAdd = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // skinComboBox
            // 
            this.skinComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox.FormattingEnabled = true;
            this.skinComboBox.Location = new System.Drawing.Point(0, 1);
            this.skinComboBox.Name = "skinComboBox";
            this.skinComboBox.Size = new System.Drawing.Size(140, 22);
            this.skinComboBox.TabIndex = 0;
            this.skinComboBox.WaterText = "";
            this.skinComboBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.skinComboBox_PreviewKeyDown);
            // 
            // skinLabelAdd
            // 
            this.skinLabelAdd.AutoSize = true;
            this.skinLabelAdd.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelAdd.BorderColor = System.Drawing.Color.White;
            this.skinLabelAdd.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelAdd.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.skinLabelAdd.Location = new System.Drawing.Point(146, -1);
            this.skinLabelAdd.Name = "skinLabelAdd";
            this.skinLabelAdd.Size = new System.Drawing.Size(26, 26);
            this.skinLabelAdd.TabIndex = 1;
            this.skinLabelAdd.Text = "+";
            this.skinLabelAdd.Click += new System.EventHandler(this.skinLabelAdd_Click);
            // 
            // SupllierComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.skinComboBox);
            this.Controls.Add(this.skinLabelAdd);
            this.Name = "SupllierComboBox";
            this.Size = new System.Drawing.Size(175, 27);
            this.SizeChanged += new System.EventHandler(this.SupllierComboBox_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CCWin.SkinControl.SkinComboBox skinComboBox;
        private CCWin.SkinControl.SkinLabel skinLabelAdd;
    }
}
