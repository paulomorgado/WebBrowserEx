using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Pajocomo.Windows.Forms
{
    internal static class NativeWindowShim
    {
        private static readonly MethodInfo assignHandleMethodInfo;

        static NativeWindowShim()
        {
            Type nativeWindowType = typeof(NativeWindow);

            NativeWindowShim.assignHandleMethodInfo = nativeWindowType.GetMethod("AssignHandle",
                BindingFlags.Static | BindingFlags.NonPublic, null, new Type[] { typeof(IntPtr), typeof(bool) }, null);
        }

        internal static void AssignHandle(NativeWindow nativeWindow, IntPtr handle, bool assignUniqueID)
        {
            NativeWindowShim.assignHandleMethodInfo.Invoke(nativeWindow, new object[] { handle, assignUniqueID });
        }
    }
}
