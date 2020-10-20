using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text; 
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using VLCPlayer.components;

namespace VLCPlayer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
             }
        Boolean isPlaying = false;
        Boolean isStop = false;
        int rows = 1;
        int columns = 1;
        VlCControlExt[] vlcControls = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            // this.vlcControl2.VlcLibDirectory = "@C:\\Program Files\VideoLAN\VLC";
            //   vlcControl2.Play("rtsp://admin:admin123@192.168.1.33:554/H.264/ch1/main/av_stream");
          //  vlcControl1.Stopped += VlcControl2_Stopped;
          //  vlcControl1.Playing += VlcControl2_Playing;
          

        }

        private void VlcControl2_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            isPlaying = true;
            isStop = false;
        }

        private void VlcControl2_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            isPlaying = false;
            isStop = true;
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {

            if (isStop)
            {
                foreach (SkinPanel item in skinFlowLayoutPanel1.Controls)
                {
                    VlCControlExt vlcControl =  item.Controls[0] as VlCControlExt;
                    vlcControl.vlcControl1.Play();
                }
               // vlcControl1.Play();
            } else {
                foreach (SkinPanel item in skinFlowLayoutPanel1.Controls)
                {
                    VlCControlExt vlcControl = item.Controls[0] as VlCControlExt;
                    vlcControl.vlcControl1.Play(skinTextBoxUrl.Text);
                }

             //   vlcControl1.Play(skinTextBoxUrl.Text);
            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            foreach (SkinPanel item in skinFlowLayoutPanel1.Controls)
            {
                VlCControlExt vlcControl = item.Controls[0] as VlCControlExt;
                try
                {
                    vlcControl.vlcControl1.Stop();
                }
                catch   { }
            }

           // vlcControl1.Stop();
        }

        private void skinFlowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (SkinPanel skinPanel in skinFlowLayoutPanel1.Controls)
            {
                skinPanel.Width = this.skinFlowLayoutPanel1.Width / columns- 10;
                skinPanel.Height = this.skinFlowLayoutPanel1.Height / rows - 10;
            }
          
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
          
            CheckGrid();
            if (vlcControls != null)
            {
                foreach (var item in vlcControls)
                {
                    item.vlcControl1.Stopped += Item_Stopped;
                } 
            }
            skinButton2_Click(null, null);
            vlcControls = new VlCControlExt[(int)skinNumericUpDown1.Value];
            skinFlowLayoutPanel1.Controls.Clear();
            // skinFlowLayoutPanel1.Controls.Add(vlcControl1);
            for (int i = 0; i < skinNumericUpDown1.Value; i++)
            {
                SkinPanel skinPanel = new SkinPanel();
                VlCControlExt vlcControl = new VlCControlExt();

              //  skinFlowLayoutPanel1.SuspendLayout();
             //   skinPanel.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(vlcControl.vlcControl1)).BeginInit();
                vlcControl.vlcControl1.BackColor = System.Drawing.Color.Black;
                //vlcControl.Dock = System.Windows.Forms.DockStyle.Fill;
                //  vlcControl.Location = new System.Drawing.Point(0, 39);
                vlcControl.vlcControl1.Name = "vlcControl-" + i;
                vlcControl.vlcControl1.Size = new System.Drawing.Size(681, 274);
                vlcControl.vlcControl1.Spu = -1;
              //  vlcControl.TabIndex = 4;
                vlcControl.vlcControl1.Text = "vlcControl-" + i;
                // vlcControl.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcControl2.VlcLibDirectory")));
                vlcControl.vlcControl1.VlcMediaplayerOptions = null;

                vlcControl.vlcControl1.Stopped += VlcControl2_Stopped;
                vlcControl.vlcControl1.Playing += VlcControl2_Playing;
                skinPanel.Width = this.skinFlowLayoutPanel1.Width / columns - 10;
                skinPanel.Height = this.skinFlowLayoutPanel1.Height / rows - 10;
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
                vlcControl.vlcControl1.VlcLibDirectory = new DirectoryInfo("E:\\studio\\study\\VLC");
                vlcControl.Dock = DockStyle.Fill;
                // vlcControl.VlcMediaplayerOptions = null;
                skinPanel.Controls.Add(vlcControl);
                 vlcControls[i] = vlcControl;
                skinFlowLayoutPanel1.Controls.Add(skinPanel);
             //   skinPanel.ResumeLayout(false);
               ((System.ComponentModel.ISupportInitialize)(vlcControl.vlcControl1)).EndInit();

            }
            isStop = false; isPlaying = false;
            // skinFlowLayoutPanel1.ResumeLayout(false);

        }

        private void Item_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            //VlcControl vlcControl = sender as VlcControl;
            //vlcControl.Dispose();
            //vlcControl = null;
        }

        private void CheckGrid()
        {
            int size = int.Parse(skinNumericUpDown1.Value.ToString());
            rows = 1;
            columns = 1;
            if (size > 1)
            {
                rows = 1;
                columns = 2;

            }
            if (size > 2)
            {
                rows =2; 
                columns =2;

            }
            if (size > 4)
            {
                rows = 2;
                columns = 3;
            }
            if (size > 6)
            {
                rows = 3;
                columns = 3;
            }
        }
    }
}
