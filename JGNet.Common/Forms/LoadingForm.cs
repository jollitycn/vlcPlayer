using CCWin;
using JGNet.Common; 
using CJPlus.Rapid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class LoadingForm : BaseForm
    {  
        public LoadingForm( )
        {
            InitializeComponent();
            skinRollingBar1.StartRolling();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        { 
        }
         
    }
}
