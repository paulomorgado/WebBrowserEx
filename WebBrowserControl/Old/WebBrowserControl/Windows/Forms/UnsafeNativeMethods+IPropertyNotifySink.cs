using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// Standard notification interface that supports bindable and request-edit properties.
        /// </summary>
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9BFBBC02-EFF1-101A-84ED-00AA00341D07")]
        public interface IPropertyNotifySink
        {
            /// <summary>
            /// Notifies a sink that the [bindable] property specified by <paramref name="dispID"/> has changed
            /// </summary>
            /// <param name="dispID">Dispatch identifier of the property that changed, or DISPID_UNKNOWN if multiple properties have changed.</param>
            void OnChanged(
                int dispID);

            /// <summary>
            /// Notifies a sink that a [requestedit] property is about to change and that the object is asking the sink how to proceed.
            /// </summary>
            /// <param name="dispID">Dispatch identifier of the property that is about to change or DISPID_UNKNOWN if multiple properties are about to change.</param>
            void OnRequestEdit(
                int dispID);
        }
    }
}
