namespace CJBasic.Helpers
{
    using System;
    using System.Windows.Forms;

    public static class DraggerHelper
    {
        private static DraggerHelperCore helper = new DraggerHelperCore();

        public static void DisableDrag(Control control)
        {
            helper.DisableDrag(control);
        }

        public static void EnableDrag(Control control)
        {
            helper.EnableDrag(control);
        }

        public static bool IsControlCanDrag(Control control)
        {
            return helper.IsControlCanDrag(control);
        }
    }
}

