namespace CJBasic.Widget.Internals
{
    using CJBasic.Widget;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    internal class RichEditOle
    {
        private AgileRichTextBox agileRichTextBox;
        private CJBasic.Widget.Internals.IRichEditOle richEditOle;

        public RichEditOle(AgileRichTextBox _richEdit)
        {
            this.agileRichTextBox = _richEdit;
        }

        public List<REOBJECT> GetAllREOBJECT()
        {
            List<REOBJECT> list = new List<REOBJECT>();
            int objectCount = this.IRichEditOle.GetObjectCount();
            for (int i = 0; i < objectCount; i++)
            {
                REOBJECT lpreobject = new REOBJECT();
                this.IRichEditOle.GetObject(i, lpreobject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
                list.Add(lpreobject);
            }
            return list;
        }

        private Size GetSizeFromMillimeter(REOBJECT lpreobject)
        {
            using (Graphics graphics = Graphics.FromHwnd(this.agileRichTextBox.Handle))
            {
                Point[] pts = new Point[1];
                graphics.PageUnit = GraphicsUnit.Millimeter;
                pts[0] = new Point(lpreobject.sizel.Width / 100, lpreobject.sizel.Height / 100);
                graphics.TransformPoints(CoordinateSpace.Device, CoordinateSpace.Page, pts);
                return new Size(pts[0]);
            }
        }

        public void InsertControl(Control control)
        {
            this.InsertControl(control, this.agileRichTextBox.TextLength, 1);
        }

        public void InsertControl(Control control, int position, uint dwUser)
        {
            if (control != null)
            {
                CJBasic.Widget.Internals.ILockBytes bytes;
                CJBasic.Widget.Internals.IStorage storage;
                CJBasic.Widget.Internals.IOleClientSite site;
                Guid guid = Marshal.GenerateGuidForType(control.GetType());
                CJBasic.Widget.Internals.NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out bytes);
                CJBasic.Widget.Internals.NativeMethods.StgCreateDocfileOnILockBytes(bytes, 0x1012, 0, out storage);
                this.IRichEditOle.GetClientSite(out site);
                REOBJECT lpreobject = new REOBJECT();
                lpreobject.posistion = position;
                lpreobject.clsid = guid;
                lpreobject.pstg = storage;
                lpreobject.poleobj = Marshal.GetIUnknownForObject(control);
                lpreobject.polesite = site;
                lpreobject.dvAspect = 1;
                lpreobject.dwFlags = 2;
                lpreobject.dwUser = dwUser;
                this.IRichEditOle.InsertObject(lpreobject);
                Marshal.ReleaseComObject(bytes);
                Marshal.ReleaseComObject(site);
                Marshal.ReleaseComObject(storage);
            }
        }

        public bool InsertImageFromFile(string strFilename)
        {
            return this.InsertImageFromFile(strFilename, this.agileRichTextBox.TextLength);
        }

        public bool InsertImageFromFile(string strFilename, int position)
        {
            CJBasic.Widget.Internals.ILockBytes bytes;
            CJBasic.Widget.Internals.IStorage storage;
            CJBasic.Widget.Internals.IOleClientSite site;
            object obj2;
            CJBasic.Widget.Internals.NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out bytes);
            CJBasic.Widget.Internals.NativeMethods.StgCreateDocfileOnILockBytes(bytes, 0x1012, 0, out storage);
            this.IRichEditOle.GetClientSite(out site);
            FORMATETC pFormatEtc = new FORMATETC();
            pFormatEtc.cfFormat = (CLIPFORMAT) 0;
            pFormatEtc.ptd = IntPtr.Zero;
            pFormatEtc.dwAspect = DVASPECT.DVASPECT_CONTENT;
            pFormatEtc.lindex = -1;
            pFormatEtc.tymed = TYMED.TYMED_NULL;
            Guid riid = new Guid("{00000112-0000-0000-C000-000000000046}");
            Guid rclsid = new Guid("{00000000-0000-0000-0000-000000000000}");
            CJBasic.Widget.Internals.NativeMethods.OleCreateFromFile(ref rclsid, strFilename, ref riid, 1, ref pFormatEtc, site, storage, out obj2);
            if (obj2 == null)
            {
                Marshal.ReleaseComObject(bytes);
                Marshal.ReleaseComObject(site);
                Marshal.ReleaseComObject(storage);
                return false;
            }
            CJBasic.Widget.Internals.IOleObject pUnk = (CJBasic.Widget.Internals.IOleObject) obj2;
            Guid pClsid = new Guid();
            pUnk.GetUserClassID(ref pClsid);
            CJBasic.Widget.Internals.NativeMethods.OleSetContainedObject(pUnk, true);
            REOBJECT lpreobject = new REOBJECT();
            lpreobject.posistion = position;
            lpreobject.clsid = pClsid;
            lpreobject.pstg = storage;
            lpreobject.poleobj = Marshal.GetIUnknownForObject(pUnk);
            lpreobject.polesite = site;
            lpreobject.dvAspect = 1;
            lpreobject.dwFlags = 2;
            lpreobject.dwUser = 0;
            this.IRichEditOle.InsertObject(lpreobject);
            Marshal.ReleaseComObject(bytes);
            Marshal.ReleaseComObject(site);
            Marshal.ReleaseComObject(storage);
            Marshal.ReleaseComObject(pUnk);
            return true;
        }

        public REOBJECT InsertOleObject(CJBasic.Widget.Internals.IOleObject oleObject, int index)
        {
            return this.InsertOleObject(oleObject, index, this.agileRichTextBox.TextLength);
        }

        public REOBJECT InsertOleObject(CJBasic.Widget.Internals.IOleObject oleObject, int index, int pos)
        {
            CJBasic.Widget.Internals.ILockBytes bytes;
            CJBasic.Widget.Internals.IStorage storage;
            CJBasic.Widget.Internals.IOleClientSite site;
            if (oleObject == null)
            {
                return null;
            }
            CJBasic.Widget.Internals.NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out bytes);
            CJBasic.Widget.Internals.NativeMethods.StgCreateDocfileOnILockBytes(bytes, 0x1012, 0, out storage);
            this.IRichEditOle.GetClientSite(out site);
            Guid pClsid = new Guid();
            oleObject.GetUserClassID(ref pClsid);
            CJBasic.Widget.Internals.NativeMethods.OleSetContainedObject(oleObject, true);
            REOBJECT lpreobject = new REOBJECT();
            lpreobject.posistion = pos;
            lpreobject.clsid = pClsid;
            lpreobject.pstg = storage;
            lpreobject.poleobj = Marshal.GetIUnknownForObject(oleObject);
            lpreobject.polesite = site;
            lpreobject.dvAspect = 1;
            lpreobject.dwFlags = 2;
            lpreobject.dwUser = (uint) index;
            this.IRichEditOle.InsertObject(lpreobject);
            Marshal.ReleaseComObject(bytes);
            Marshal.ReleaseComObject(site);
            Marshal.ReleaseComObject(storage);
            return lpreobject;
        }

        public void UpdateObjects()
        {
            int objectCount = this.IRichEditOle.GetObjectCount();
            for (int i = 0; i < objectCount; i++)
            {
                REOBJECT lpreobject = new REOBJECT();
                this.IRichEditOle.GetObject(i, lpreobject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
                Point positionFromCharIndex = this.agileRichTextBox.GetPositionFromCharIndex(lpreobject.posistion);
                Rectangle rc = new Rectangle(positionFromCharIndex.X, positionFromCharIndex.Y, 50, 50);
                this.agileRichTextBox.Invalidate(rc, false);
            }
        }

        public void UpdateObjects(REOBJECT reObj)
        {
            Point positionFromCharIndex = this.agileRichTextBox.GetPositionFromCharIndex(reObj.posistion);
            Size sizeFromMillimeter = this.GetSizeFromMillimeter(reObj);
            Rectangle rc = new Rectangle(positionFromCharIndex, sizeFromMillimeter);
            this.agileRichTextBox.Invalidate(rc, false);
        }

        public void UpdateObjects(int pos)
        {
            REOBJECT lpreobject = new REOBJECT();
            this.IRichEditOle.GetObject(pos, lpreobject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
            this.UpdateObjects(lpreobject);
        }

        public CJBasic.Widget.Internals.IRichEditOle IRichEditOle
        {
            get
            {
                if (this.richEditOle == null)
                {
                    this.richEditOle = CJBasic.Widget.Internals.NativeMethods.SendMessage(this.agileRichTextBox.Handle, 0x43c, 0);
                }
                return this.richEditOle;
            }
        }
    }
}

