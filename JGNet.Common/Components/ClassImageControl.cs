using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common.Components
{
    public partial class ClassImageControl : UserControl
    {
        List<TitleImageOfCostumeClass> images = new List<TitleImageOfCostumeClass>();
       private  Image plusImage = global::JGNet.Common.Properties.Resources.plus1;
        private TitleImageOfCostumeClass selectedTitleImage =null;
      //  private TitleImageOfCostumeClass plusTitleImage =null;
        private bool isOrderIndex = true;
        public bool IsOrderIndex
        {
            get { return isOrderIndex; }
            set{ isOrderIndex = value; }
        }
        public CJBasic.Action<object, EventArgs> Upload_Click;

        public CJBasic.Action<TitleImageOfCostumeClass, EventArgs> TitleImageMoveUp { get; set; }
        public CJBasic.Action<TitleImageOfCostumeClass, EventArgs> TitleImageMoveDown { get; set; }
      /*  private bool isDisplayAddImage = true; 
        public bool IsDisplayAddImage
        {
            get { return isDisplayAddImage; }
            set { isDisplayAddImage = value; }
        }*/
        public ClassImageControl() {
            InitializeComponent();
             
              /*  plusTitleImage = new TitleImageOfCostumeClass()
                {
                    Image = plusImage,
                    CannotRemove = true,
                    Selectable = false,
                };*/
             
           // plusTitleImage.Click += PlusTitleImage_Click;
           
        }
         

        private void PlusTitleImage_Click(object sender, EventArgs e)
        {
            Upload_Click?.Invoke(sender, e);
          //  plusTitleImage.BackColor = Color.Transparent;
        }

        public void AddTitleImage(TitleImageOfCostumeClass titleImage)
        {
            this.flowLayoutPanel1.Controls.Add(titleImage);
            /*  if (isDisplayAddImage)
            {this.flowLayoutPanel1.Controls.Remove(plusTitleImage);
          
                this.flowLayoutPanel1.Controls.Add(plusTitleImage);
            }*/
            images.Add(titleImage);
            titleImage.OnSelected += TitleImageSelected;
            titleImage.OnRemoved += TitleImageRemoved;
            titleImage.Selected = true;
        }

        public void TitleImageRemoved(TitleImageOfCostumeClass selectedTitle, EventArgs args)
        {
            this.images.Remove(selectedTitle);
        }
        public void TitleImageSelected(TitleImageOfCostumeClass selectedTitle, EventArgs args)
        {
            selectedTitleImage = selectedTitle;
            foreach (TitleImageOfCostumeClass item in this.images)
            {
                if (item != selectedTitle)
                {
                    item.Selected = false;
                }

            }
        }

        public void RemoveTitleImage(TitleImageOfCostumeClass image)
        {
            this.flowLayoutPanel1.Controls.Add(image);
        }

         
         

        private void RefreshImages()
        {
            this.flowLayoutPanel1.Controls.Clear();
            this.flowLayoutPanel1.Controls.AddRange(images.ToArray());
           /* if (isDisplayAddImage)
            {
                this.flowLayoutPanel1.Controls.Add(plusTitleImage);
            }*/
        }

        public void Clear()
        {
            images = new List<TitleImageOfCostumeClass>();
            this.flowLayoutPanel1.Controls.Clear();
           /* if (isDisplayAddImage)
            {
                this.flowLayoutPanel1.Controls.Add(plusTitleImage);
            }*/
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

        private void BannerImageControl_Load(object sender, EventArgs e)
        {
            if (!isOrderIndex)
            {
                this.panel1.Visible = false;
            }
            else
            {

                this.panel1.Visible = true;
            }
        }
    }
}
