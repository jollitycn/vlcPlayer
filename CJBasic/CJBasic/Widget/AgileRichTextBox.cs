namespace CJBasic.Widget
{
    using CJBasic.Collections;
    using CJBasic.Widget.Internals;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class AgileRichTextBox : RichTextBox
    {
        private IImagePathGetter imagePathGetter = new DefaultImagePathGetter();
        private CJBasic.Widget.Internals.RichEditOle richEditOle;

        public void AppendRichText(string textContent, SortedArray<int, uint> imagePosition_imageID, Font font, Color color)
        {
            int length = this.Text.Length;
            if (imagePosition_imageID != null)
            {
                int num2;
                string text = textContent;
                List<int> allKeyList = imagePosition_imageID.GetAllKeyList();
                for (num2 = allKeyList.Count - 1; num2 >= 0; num2--)
                {
                    text = text.Remove(allKeyList[num2], 1);
                }
                base.AppendText(text);
                for (num2 = 0; num2 < allKeyList.Count; num2++)
                {
                    int num3 = allKeyList[num2];
                    this.InsertImage(imagePosition_imageID[num3], length + num3);
                }
            }
            else
            {
                base.AppendText(textContent);
            }
            base.Select(length, textContent.Length);
            base.SelectionColor = color;
            if (font != null)
            {
                base.SelectionFont = font;
            }
        }

        public void AppendRichText(string textContent, SortedArray<int, uint> imagePosition_imageID, Dictionary<int, Image> foreignObjectAry, Font font, Color color)
        {
            int length = this.Text.Length;
            if (imagePosition_imageID != null)
            {
                int num3;
                string text = textContent;
                List<int> allKeyList = imagePosition_imageID.GetAllKeyList();
                List<int> list2 = new List<int>();
                list2.AddRange(allKeyList);
                foreach (int num2 in foreignObjectAry.Keys)
                {
                    list2.Add(num2);
                }
                list2.Sort();
                for (num3 = list2.Count - 1; num3 >= 0; num3--)
                {
                    text = text.Remove(list2[num3], 1);
                }
                base.AppendText(text);
                for (num3 = 0; num3 < list2.Count; num3++)
                {
                    int item = list2[num3];
                    if (allKeyList.Contains(item))
                    {
                        this.InsertImage(imagePosition_imageID[item], length + item);
                    }
                    else
                    {
                        this.InsertImage(foreignObjectAry[item], length + item);
                    }
                }
            }
            else
            {
                base.AppendText(textContent);
            }
            base.Select(length, textContent.Length);
            base.SelectionColor = color;
            if (font != null)
            {
                base.SelectionFont = font;
            }
        }

        public void AppendRtf(string _rtf)
        {
            base.Select(this.TextLength, 0);
            base.SelectedRtf = _rtf;
            base.Update();
            base.Select(base.Rtf.Length, 0);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public SortedArray<int, uint> GetAllImage(out bool containsForeignObject)
        {
            containsForeignObject = false;
            SortedArray<int, uint> array = new SortedArray<int, uint>();
            List<REOBJECT> allREOBJECT = this.RichEditOle.GetAllREOBJECT();
            for (int i = 0; i < allREOBJECT.Count; i++)
            {
                if (allREOBJECT[i].dwUser != 0)
                {
                    array.Add(allREOBJECT[i].posistion, allREOBJECT[i].dwUser);
                }
                else
                {
                    containsForeignObject = true;
                }
            }
            return array;
        }

        public void Initialize(IImagePathGetter getter)
        {
            this.imagePathGetter = getter;
        }

        public void InsertImage(Image image, int position)
        {
            GifBox control = new GifBox();
            control.BackColor = base.BackColor;
            control.Image = image;
            this.RichEditOle.InsertControl(control, position, 0);
        }

        public void InsertImage(uint imageID, int position)
        {
            if (imageID <= 0)
            {
                throw new Exception("imageID must greater than 0.");
            }
            GifBox control = new GifBox();
            control.BackColor = base.BackColor;
            control.Image = Image.FromFile(this.imagePathGetter.GetPath(imageID));
            this.RichEditOle.InsertControl(control, position, imageID);
        }

        private CJBasic.Widget.Internals.RichEditOle RichEditOle
        {
            get
            {
                if ((this.richEditOle == null) && base.IsHandleCreated)
                {
                    this.richEditOle = new CJBasic.Widget.Internals.RichEditOle(this);
                }
                return this.richEditOle;
            }
        }
    }
}

