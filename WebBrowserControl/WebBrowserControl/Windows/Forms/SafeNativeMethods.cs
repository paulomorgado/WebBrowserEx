using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    internal class SafeNativeMethods
    {
        /// <summary>
        /// Defines a new window message that is guaranteed to be unique throughout the system.
        /// </summary>
        /// <param name="msg">String that specifies the message to be registered.</param>
        /// <returns>If the message is successfully registered, the return value is a message identifier in the range 0xC000 through 0xFFFF.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int RegisterWindowMessage(string msg);

        /// <summary>
        /// Retrieves the number of milliseconds that have elapsed since the system was started.
        /// </summary>
        /// <returns>The number of milliseconds that have elapsed since the system was started.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetTickCount();

        /// <summary>
        /// Determines whether the keystroke maps to an accelerator in the given accelerator table.
        /// </summary>
        /// <param name="hAccel">Handle to the accelerator table.</param>
        /// <param name="cAccelEntries">Number of entries in the accelerator table.</param>
        /// <param name="lpMsg">Pointer to the keystroke message to be translated.</param>
        /// <param name="lpwCmd">Pointer to where to return the corresponding command identifier if there is an accelerator for the keystroke. It may be <see langword="null"/>.</param>
        /// <returns>
        /// 	If <see langword="true"/>, the message is for the object application; otherwise, the message is not for the object and should be forwarded to the container.
        /// </returns>
        [DllImport("ole32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsAccelerator(HandleRef hAccel, int cAccelEntries, [In] ref NativeMethods.MSG lpMsg, short[] lpwCmd);
    }
}
