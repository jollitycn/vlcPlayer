using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Text; 
using System.Windows.Forms;

namespace VLCPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
             }

        Boolean stoped = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            // this.vlcControl2.VlcLibDirectory = "@C:\\Program Files\VideoLAN\VLC";
            //   vlcControl2.Play("rtsp://admin:admin123@192.168.1.33:554/H.264/ch1/main/av_stream");
            vlcControl2.Stopped += VlcControl2_Stopped;
            vlcControl2.Playing += VlcControl2_Playing;
        }

        private void VlcControl2_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            stoped = false;
        }

        private void VlcControl2_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            stoped = true;
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {

            if (stoped)
            {
                vlcControl2.Play();
            } else {
                vlcControl2.Play(skinTextBoxUrl.Text);
            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            vlcControl2.Stop();
        }
    }
}
