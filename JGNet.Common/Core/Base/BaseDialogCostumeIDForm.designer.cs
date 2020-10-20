namespace JGNet.Common
{
    partial class BaseDialogCostumeIDForm : BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.BorderPalace = ((System.Drawing.Image)(resources.GetObject("$this.BorderPalace")));
            this.ClientSize = new System.Drawing.Size(353, 228);
            this.CloseDownBack = global::JGNet.Common.Properties.Resources.btn_close_down;
            this.CloseMouseBack = global::JGNet.Common.Properties.Resources.btn_close_highlight;
            this.CloseNormlBack = global::JGNet.Common.Properties.Resources.btn_close_disable;
            this.MaxDownBack = global::JGNet.Common.Properties.Resources.btn_max_down;
            this.MaximizeBox = false;
            this.MaxMouseBack = global::JGNet.Common.Properties.Resources.btn_max_highlight;
            this.MaxNormlBack = global::JGNet.Common.Properties.Resources.btn_max_normal;
            this.MiniDownBack = global::JGNet.Common.Properties.Resources.btn_mini_down;
            this.MinimizeBox = false;
            this.MiniMouseBack = global::JGNet.Common.Properties.Resources.btn_mini_highlight;
            this.MiniNormlBack = global::JGNet.Common.Properties.Resources.btn_mini_normal;
            this.Name = "BaseForm";
            this.RestoreDownBack = global::JGNet.Common.Properties.Resources.btn_restore_down;
            this.RestoreMouseBack = global::JGNet.Common.Properties.Resources.btn_restore_highlight;
            this.RestoreNormlBack = global::JGNet.Common.Properties.Resources.btn_restore_normal;
            this.ResumeLayout(false);

        }

        #endregion
    }
}