namespace CJBasic.ObjectManagement.Trees.Binary
{
    using System;
    using System.Drawing;

    public class DrawerParas
    {
        public SolidBrush BrushNode;
        public SolidBrush BrushText;
        public Font FontText;
        public Graphics Graphic;
        public Color GraphicBackColor;
        public Pen PenLine;
        public Pen PenNode;
        public int Radius;

        public DrawerParas()
        {
            this.Graphic = null;
            this.GraphicBackColor = Color.Gainsboro;
            this.Radius = 10;
            this.PenNode = new Pen(Color.Black, 1f);
            this.PenLine = new Pen(Color.Black, 1f);
            this.BrushNode = new SolidBrush(Color.Pink);
            this.FontText = new Font("Arial", 9f);
            this.BrushText = new SolidBrush(Color.Black);
        }

        public DrawerParas(Graphics _graphic)
        {
            this.Graphic = null;
            this.GraphicBackColor = Color.Gainsboro;
            this.Radius = 10;
            this.PenNode = new Pen(Color.Black, 1f);
            this.PenLine = new Pen(Color.Black, 1f);
            this.BrushNode = new SolidBrush(Color.Pink);
            this.FontText = new Font("Arial", 9f);
            this.BrushText = new SolidBrush(Color.Black);
            this.Graphic = _graphic;
        }
    }
}

