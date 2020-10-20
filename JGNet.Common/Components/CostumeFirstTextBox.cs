using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace JGNet.Common
{
    public partial class CostumeFirstTextBox : JGNet.Common.TextBox
    {
        public CostumeFirstTextBox()
        {
            InitializeComponent();
            this.Text = "";
            this.SkinTxt.Text = "";
        }

        public CostumeFirstTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
