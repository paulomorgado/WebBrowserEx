using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    internal static class ApplicationShim
    {
        private static readonly PropertyInfo windowMessagesVersionPropertyInfo;
        private static readonly MethodInfo parkHandleMethodInfo;
        private static readonly Type parkingWindowType;

        static ApplicationShim()
        {
            Type windowsFormsApplicationType = typeof(Application);

            ApplicationShim.windowMessagesVersionPropertyInfo = windowsFormsApplicationType.GetProperty("WindowMessagesVersion",
                BindingFlags.Static | BindingFlags.NonPublic, null, typeof(string), new Type[] {}, null);

            ApplicationShim.parkHandleMethodInfo = windowsFormsApplicationType.GetMethod("ParkHandle",
                BindingFlags.Static | BindingFlags.NonPublic, null, new Type[] { typeof(HandleRef)  }, null);

            ApplicationShim.parkingWindowType = Type.GetType(windowsFormsApplicationType.FullName + "+ParkingWindow, " + windowsFormsApplicationType.Assembly.FullName);
        }

        internal static string WindowMessagesVersion
        {
            get
            {
                return (string)(ApplicationShim.windowMessagesVersionPropertyInfo.GetValue(null, new object[0] { }));
            }
        }

        internal static bool IsParkingWindow(ContainerControl containerControl)
        {
            return (containerControl == null) ? false : ApplicationShim.parkingWindowType.IsAssignableFrom(containerControl.GetType());
        }

        internal static void ParkHandle(HandleRef handle)
        {
            ApplicationShim.parkHandleMethodInfo.Invoke(null, new object[] { handle });
        }
    }
}
