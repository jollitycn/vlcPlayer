﻿namespace CJBasic.Widget
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class GifBox : Control
    {
        private Color _borderColor = Color.Transparent;
        private bool _canAnimate = false;
        private EventHandler _eventAnimator;
        private System.Drawing.Image _image;
        private Rectangle _imageRectangle;

        public GifBox()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.CacheText | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.Opaque, false);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                this._eventAnimator = null;
                this._canAnimate = false;
                if (this._image != null)
                {
                    this._image = null;
                }
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            this.StopAnimate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this._image != null)
            {
                this.UpdateImage();
                e.Graphics.DrawImage(this._image, this.ImageRectangle, 0, 0, this._image.Width, this._image.Height, GraphicsUnit.Pixel);
            }
            ControlPaint.DrawBorder(e.Graphics, base.ClientRectangle, this._borderColor, ButtonBorderStyle.Solid);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this._imageRectangle = Rectangle.Empty;
            base.OnSizeChanged(e);
        }

        private void StartAnimate()
        {
            if (this.CanAnimate)
            {
                ImageAnimator.Animate(this._image, this.EventAnimator);
            }
        }

        private void StopAnimate()
        {
            if (this.CanAnimate)
            {
                ImageAnimator.StopAnimate(this._image, this.EventAnimator);
            }
        }

        private void UpdateImage()
        {
            if (this.CanAnimate)
            {
                ImageAnimator.UpdateFrames(this._image);
            }
        }

        public Color BorderColor
        {
            get
            {
                return this._borderColor;
            }
            set
            {
                this._borderColor = value;
                base.Invalidate();
            }
        }

        private bool CanAnimate
        {
            get
            {
                return this._canAnimate;
            }
        }

        private EventHandler EventAnimator
        {
            get
            {
                if (this._eventAnimator == null)
                {
                    this._eventAnimator = delegate (object sender, EventArgs e) {
                        base.Invalidate(this.ImageRectangle);
                    };
                }
                return this._eventAnimator;
            }
        }

        public System.Drawing.Image Image
        {
            get
            {
                return this._image;
            }
            set
            {
                this.StopAnimate();
                this._image = value;
                this._imageRectangle = Rectangle.Empty;
                if (value != null)
                {
                    this._canAnimate = ImageAnimator.CanAnimate(this._image);
                }
                else
                {
                    this._canAnimate = false;
                }
                base.Size = this.Image.Size;
                base.Invalidate(this.ImageRectangle);
                if (!base.DesignMode)
                {
                    this.StartAnimate();
                }
            }
        }

        private Rectangle ImageRectangle
        {
            get
            {
                if ((this._imageRectangle == Rectangle.Empty) && (this._image != null))
                {
                    this._imageRectangle.X = (base.Width - this._image.Width) / 2;
                    this._imageRectangle.Y = (base.Height - this._image.Height) / 2;
                    this._imageRectangle.Width = this._image.Width;
                    this._imageRectangle.Height = this._image.Height;
                }
                return this._imageRectangle;
            }
        }
    }
}

