using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Pajocomo.Windows.Forms
{
    internal static class ControlShim
    {
        private static readonly MethodInfo createControlMethodInfo;
        private static readonly MethodInfo reflectMessageInternalMethodInfo;

        static ControlShim()
        {
            Type controlType = typeof(Control);

            ControlShim.createControlMethodInfo = controlType.GetMethod("CreateControl",
                BindingFlags.Static | BindingFlags.NonPublic, null, new Type[] { typeof(bool) }, null);

            ControlShim.reflectMessageInternalMethodInfo = controlType.GetMethod("ReflectMessageInternal",
                BindingFlags.Static | BindingFlags.NonPublic, null, new Type[] { typeof(IntPtr), typeof(Message) }, null);
        }

        internal static void CreateControl(Control control, bool fIgnoreVisible)
        {
            ControlShim.createControlMethodInfo.Invoke(control, new object[] { fIgnoreVisible });
        }

        internal static bool ReflectMessageInternal(IntPtr hWnd, ref Message m)
        {
            return (bool)ControlShim.createControlMethodInfo.Invoke(null, new object[] { hWnd, m });
        }
    }
}
