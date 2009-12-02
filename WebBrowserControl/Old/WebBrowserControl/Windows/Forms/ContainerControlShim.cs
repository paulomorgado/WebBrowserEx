using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Pajocomo.Windows.Forms
{
    internal static class ContainerControlShim
    {
        private static readonly MethodInfo setActiveControlInternalMethodInfo;

        static ContainerControlShim()
        {
            Type containerControlType = typeof(global::System.Windows.Forms.ContainerControl);

            ContainerControlShim.setActiveControlInternalMethodInfo = containerControlType.GetMethod("SetActiveControlInternal",
                BindingFlags.Static | BindingFlags.NonPublic, null, new Type[] { typeof(Control) }, null);
        }

        internal static void SetActiveControlInternal(ContainerControl containerControl, Control value)
        {
            ContainerControlShim.setActiveControlInternalMethodInfo.Invoke(containerControl, new object[] { value });
        }
    }
}
