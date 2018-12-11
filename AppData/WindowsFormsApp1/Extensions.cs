using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class Extensions
    {
        public static void Open(this Panel panel)
        {
            panel.BringToFront();
            panel.Visible = true;
        }
        public static void Close(this Panel panel)
        {
            panel.SendToBack();
            panel.Visible = false;
        }
       
    }
}