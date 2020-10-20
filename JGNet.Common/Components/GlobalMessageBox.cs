using CCWin;
using JGNet.Core.Const;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JGNet.Common
{
  public static   class GlobalMessageBox
    {
        /// <summary>
        /// 使用系统设置的默认提示内容
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult Show(string text)
        {
            return MessageBoxEx.Show(text, SystemDefault.SolutionName);
        }

        public static DialogResult Show(string text,String caption)
        {
            return MessageBoxEx.Show(text, caption);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBoxEx.Show(text, caption, buttons, icon);
        }

        public static DialogResult Show(Form form, string content)
        {
            return MessageBoxEx.Show(form, content, SystemDefault.SolutionName);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return MessageBoxEx.Show(text, caption, buttons);
        }

        public static DialogResult ShowError(Form form, string content)
        {
            return GlobalErrorMessageBox.Show(form, content, SystemDefault.SolutionName);
        }
         
    }
}
