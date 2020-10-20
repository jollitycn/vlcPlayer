namespace JGNet.Common
{
    partial class DateSelectForm
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
            this.BaseButton_Cancel = new JGNet.Common.Components.BaseButton();
            this.BaseButton_OK = new JGNet.Common.Components.BaseButton();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseButton_Cancel
            // 
            this.BaseButton_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton_Cancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton_Cancel.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton_Cancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton_Cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton_Cancel.Location = new System.Drawing.Point(143, 64);
            this.BaseButton_Cancel.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton_Cancel.Name = "BaseButton_Cancel";
            this.BaseButton_Cancel.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton_Cancel.Size = new System.Drawing.Size(75, 32);
            this.BaseButton_Cancel.TabIndex = 1;
            this.BaseButton_Cancel.Text = "取消";
            this.BaseButton_Cancel.UseVisualStyleBackColor = false;
            this.BaseButton_Cancel.Click += new System.EventHandler(this.BaseButton_Cancel_Click);
            // 
            // BaseButton_OK
            // 
            this.BaseButton_OK.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton_OK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton_OK.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton_OK.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton_OK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton_OK.Location = new System.Drawing.Point(62, 64);
            this.BaseButton_OK.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton_OK.Name = "BaseButton_OK";
            this.BaseButton_OK.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton_OK.Size = new System.Drawing.Size(75, 32);
            this.BaseButton_OK.TabIndex = 0;
            this.BaseButton_OK.Text = "确定";
            this.BaseButton_OK.UseVisualStyleBackColor = false;
            this.BaseButton_OK.Click += new System.EventHandler(this.BaseButton_OK_Click);
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(3, 34);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(68, 17);
            this.skinLabel4.TabIndex = 0;
            this.skinLabel4.Text = "修改日期：";
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(77, 32);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_Start.TabIndex = 4;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.Red;
            this.skinLabel1.Location = new System.Drawing.Point(3, 11);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(112, 17);
            this.skinLabel1.TabIndex = 5;
            this.skinLabel1.Text = "正在重新结算中……";
            this.skinLabel1.Visible = false;
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.skinLabel1);
            this.skinPanel2.Controls.Add(this.skinLabel4);
            this.skinPanel2.Controls.Add(this.dateTimePicker_Start);
            this.skinPanel2.Controls.Add(this.BaseButton_OK);
            this.skinPanel2.Controls.Add(this.BaseButton_Cancel);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(4, 28);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(233, 106);
            this.skinPanel2.TabIndex = 6;
            // 
            // DateSelectForm
            // 
            this.AcceptButton = this.BaseButton_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 138);
            this.Controls.Add(this.skinPanel2);
            this.Name = "DateSelectForm";
            this.Text = "请选择";
            this.Load += new System.EventHandler(this.SelectGuideForm_Load);
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Common.Components.BaseButton BaseButton_Cancel;
        private Common.Components.BaseButton BaseButton_OK;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinPanel skinPanel2;
    }
}