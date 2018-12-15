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

        public static List<T> GetTasks<T>(this List<Task> tasks) where T : Task
        {
            List<T> result = new List<T>();
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].GetType() is T) result.Add((T)tasks[i]);
            }
            return result;
        }

    }
}