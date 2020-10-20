using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common.Components
{
    public partial class TitleImageControl : UserControl
    {
        List<TitleImage> images = new List<TitleImage>();
       private  Image plusImage = global::JGNet.Common.Properties.Resources.plus1;
        private TitleImage selectedTitleImage;
        private TitleImage plusTitleImage;

        public CJBasic.Action<object, EventArgs> Upload_Click;

        public CJBasic.Action<TitleImage, EventArgs> TitleImageMoveUp { get; set; }
        public CJBasic.Action<TitleImage, EventArgs> TitleImageMoveDown { get; set; }

        public TitleImageControl() {
            InitializeComponent();
            plusTitleImage = new TitleImage()
            {
                Image = plusImage,
                CannotRemove = true,
                Selectable = false,
            };
            plusTitleImage.Click += PlusTitleImage_Click; 
        }
         

        private void PlusTitleImage_Click(object sender, EventArgs e)
        {
            Upload_Click?.Invoke(sender, e);
            plusTitleImage.BackColor = Color.Transparent;
        }

        public void AddTitleImage(TitleImage titleImage)
        {
            this.flowLayoutPanel1.Controls.Add(titleImage);
            this.flowLayoutPanel1.Controls.Remove(plusTitleImage);
            this.flowLayoutPanel1.Controls.Add(plusTitleImage);
            images.Add(titleImage);
            titleImage.OnSelected += TitleImageSelected;
            titleImage.OnRemoved += TitleImageRemoved;
            titleImage.Selected = true;
        }

        public void TitleImageRemoved(TitleImage selectedTitle, EventArgs args)
        {
            this.images.Remove(selectedTitle);
        }
        public void TitleImageSelected(TitleImage selectedTitle, EventArgs args)
        {
            selectedTitleImage = selectedTitle;
            foreach (TitleImage item in this.images)
            {
                if (item != selectedTitle)
                {
                    item.Selected = false;
                }

            }
        }

        public void RemoveTitleImage(TitleImage image)
        {
            this.flowLayoutPanel1.Controls.Add(image);
        }

         
         

        private void RefreshImages()
        {
            this.flowLayoutPanel1.Controls.Clear();
            this.flowLayoutPanel1.Controls.AddRange(images.ToArray());
            this.flowLayoutPanel1.Controls.Add(plusTitleImage);
        }

        public void Clear()
        {
            images = new List<TitleImage>();
            this.flowLayoutPanel1.Controls.Clear();
            this.flowLayoutPanel1.Controls.Add(plusTitleImage);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BaseButton3_Click(object sender, EventArgs e)
        {
            int index = images.IndexOf(selectedTitleImage);

            if (index > 0)
            {      //先删除，再在index+1
                images.Remove(selectedTitleImage);
                images.Insert(index - 1, selectedTitleImage);
                RefreshImages();
                TitleImageMoveUp?.Invoke(selectedTitleImage, e);
            } 
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            int index = images.IndexOf(selectedTitleImage);

            if (index < images.Count - 1)
            { //先删除，再在index+1
                images.Remove(selectedTitleImage);
                images.Insert(index + 1, selectedTitleImage);
                RefreshImages();
                TitleImageMoveDown?.Invoke(selectedTitleImage, e);
            }

        }
    }
}
