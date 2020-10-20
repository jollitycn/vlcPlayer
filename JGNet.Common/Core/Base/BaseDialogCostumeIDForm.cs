using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.Win32;
using CCWin.Win32.Const;
using System.Diagnostics;
using System.Configuration;
using Microsoft.Win32;

namespace JGNet.Common
{
    /// <summary>
    /// JGNet.Common中所有Form的基类。使其拥有一致的皮肤和Icon。
    /// </summary>
    public partial class BaseDialogCostumeIDForm : BaseForm
    { 
        public BaseDialogCostumeIDForm()
        {
            InitializeComponent(); 
        }
        public String BaseModifyCostumeID { get; set; }
        protected void HighlightCostume(DataGridViewRow row, String costumeID)
        {

            if (!String.IsNullOrEmpty(BaseModifyCostumeID) && BaseModifyCostumeID.Equals(costumeID))
            {
                row.DefaultCellStyle.ApplyStyle(new DataGridViewCellStyle()
                {
                    BackColor = Color.LightSkyBlue
                });

            }

        }



        public virtual void HighlightCostume()
        {
        }
    }
}
