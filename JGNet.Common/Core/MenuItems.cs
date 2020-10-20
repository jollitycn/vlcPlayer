
using JGNet.Common.Core;
using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public class MenuItems
    {
        public static ToolStripMenuItem NewMenuItem(RolePermissionMenuEnum text)
        {
            return NewMenuItem(EnumHelper.GetDescription(text)) ;
        }

        public static ToolStripMenuItem NewMenuItem(string text)
        {
            return new ToolStripMenuItem() { Text = text };
        }

        public static ToolStripMenuItem NewUserControlMenuItem(RolePermissionMenuEnum text, Type tag, CJBasic.Action<object, EventArgs> toolStripMenuItem_Click, Image image = null)
        {
            return NewUserControlMenuItem(EnumHelper.GetDescription(text),tag,toolStripMenuItem_Click,image);
        }

        public static ToolStripMenuItem NewUserControlMenuItem(string text, Type tag, CJBasic.Action<object, EventArgs> toolStripMenuItem_Click, Image image = null)
        { 
            ToolStripMenuItem item = new ToolStripMenuItem() { Text = text, Tag = tag, Name = (tag.Name + "#" + 0) };
            item.Click += new EventHandler(toolStripMenuItem_Click);
            item.Image = image;
            item.ImageScaling = ToolStripItemImageScaling.None;
            return item;
        }

        public static ToolStripMenuItem NewUserControlMenuItem(string text, Type tag, int id, CJBasic.Action<object, EventArgs> toolStripMenuItem_Click)
        {
            ToolStripMenuItem item = new ToolStripMenuItem() { Text = text, Tag = tag, Name = (tag.Name + "#" + id) };
            item.Click += new EventHandler(toolStripMenuItem_Click);
            return item;
        }

        public static ToolStripButton ToolStripButton(RolePermissionMenuEnum text, Image image, EventHandler eventHandler)
        {
            return ToolStripButton(EnumHelper.GetDescription(text), image, eventHandler);
        }

        public static ToolStripButton ToolStripButton(String text, Image image, EventHandler eventHandler)
        {
            ToolStripButton b = new ToolStripButton();
            b.Image = image;
            b.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.SizeToFit;
            b.ImageTransparentColor = System.Drawing.Color.Magenta;
            //b.Name = name;
            b.Size = new System.Drawing.Size(45, 53);
            b.Text = text;
            b.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            b.Click += eventHandler;
            return b;
        }

        public static ToolStripDropDownButton ToolStripDropDownButton(RolePermissionMenuEnum text, Image image, EventHandler eventHandler = null)
        {
            return ToolStripDropDownButton(EnumHelper.GetDescription(text), image,eventHandler);
        }

        public static ToolStripDropDownButton ToolStripDropDownButton(String text, Image image , EventHandler eventHandler = null)
        {
            ToolStripDropDownButton b = new ToolStripDropDownButton();
            if (eventHandler != null)
            {
                b.Click += eventHandler;
            }
            b.Image = image;
            b.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.SizeToFit;
            b.ImageTransparentColor = System.Drawing.Color.Magenta;
            //b.Name = name;
            b.Size = new System.Drawing.Size(45, 53);
            b.Text = text;
            b.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            return b;
        } 

        public static List<ToolStripItem> GetAllMenus(ToolStripItemCollection menus)
        {
            List<ToolStripItem> allMenus = new List<ToolStripItem>();
            foreach (ToolStripItem item in menus)
            {
                //item.Tag = 0;
                if (!(item is ToolStripSeparator))
                {
                    allMenus.Add(item);
                }

                if (item is ToolStripButton)
                {
                    //ToolStripButton button = item as ToolStripButton;
                    //if(button.)
                }
                else if (item is ToolStripDropDownButton)
                {
                    ToolStripDropDownButton ddb = item as ToolStripDropDownButton;
                    if (ddb.DropDownItems != null && ddb.DropDownItems.Count > 0)
                    {
                        allMenus.AddRange(GetAllMenus(ddb.DropDownItems));
                    }
                }
                else if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem ddb = item as ToolStripMenuItem;
                    if (ddb.DropDownItems != null && ddb.DropDownItems.Count > 0)
                    {
                        allMenus.AddRange(GetAllMenus(ddb.DropDownItems));
                    }
                }
            }
            return allMenus;
        }
    }
}
