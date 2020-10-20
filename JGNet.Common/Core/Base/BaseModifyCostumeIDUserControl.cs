using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Common;

namespace JGNet.Common.Core
{
    public  partial class BaseModifyCostumeIDUserControl : BaseModifyUserControl
    {
        public String BaseModifyCostumeID { get; set; }
        protected void HighlightCostume (DataGridViewRow row,String costumeID){

            if (!String.IsNullOrEmpty(BaseModifyCostumeID) && BaseModifyCostumeID.Equals(costumeID))
            {
                row.DefaultCellStyle.ApplyStyle(new DataGridViewCellStyle()
                {
                    BackColor = Color.LightSkyBlue
                });
                 
            }

        }



        public virtual void HighlightCostume() {
        }
    }
}
