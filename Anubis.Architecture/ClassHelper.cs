using System;
using System.Windows.Forms;

namespace Anubis.Architecture
{
    public static class ClassHelper
    {
        public static void SafeBeginInvoke(Control control, Action action)
        {
            if (control.InvokeRequired)
                control.BeginInvoke(new MethodInvoker(() => { action(); }));
            else
                action();
        }

        public static void SafeInvoke(Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(new MethodInvoker(() => { action(); }));
            else
                action();
        }
    }
}
