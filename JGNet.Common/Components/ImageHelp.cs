using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Common.Core;  

namespace JGNet.Common.Components
{
    public partial class ImageHelp : UserControl
    {
        public UserControl Control { get; set; }
        public Image Image{get;set;}
        public ImageHelp()
        { 
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            ImageHelpForm imageHelpForm = new ImageHelpForm(this.Image);
            imageHelpForm.BringToFront();
            
            imageHelpForm.ShowDialog();
        }
         
    }
}
