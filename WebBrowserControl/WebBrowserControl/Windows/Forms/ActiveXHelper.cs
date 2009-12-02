using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace Pajocomo.Windows.Forms
{
    internal partial class ActiveXHelper
    {
        internal static readonly int AddedSelectionHandler;
        internal static readonly int InTransition;
        internal static readonly int IsMaskEdit;
        internal static readonly int ManualUpdate;
        internal static readonly int ProcessingKeyUp;
        internal static readonly int RecomputeContainingControl;
        internal static readonly int SetClientSiteFirst;
        internal static readonly int SinkAttached;
        internal static readonly int SiteProcessedInputKey;
        private static int logPixelsX;
        private static int logPixelsY;
        internal static readonly int REGMSG_MSG;

        static ActiveXHelper()
        {
            ActiveXHelper.SinkAttached = BitVector32.CreateMask();
            ActiveXHelper.ManualUpdate = BitVector32.CreateMask(ActiveXHelper.SinkAttached);
            ActiveXHelper.SetClientSiteFirst = BitVector32.CreateMask(ActiveXHelper.ManualUpdate);
            ActiveXHelper.AddedSelectionHandler = BitVector32.CreateMask(ActiveXHelper.SetClientSiteFirst);
            ActiveXHelper.SiteProcessedInputKey = BitVector32.CreateMask(ActiveXHelper.AddedSelectionHandler);
            ActiveXHelper.InTransition = BitVector32.CreateMask(ActiveXHelper.SiteProcessedInputKey);
            ActiveXHelper.ProcessingKeyUp = BitVector32.CreateMask(ActiveXHelper.InTransition);
            ActiveXHelper.IsMaskEdit = BitVector32.CreateMask(ActiveXHelper.ProcessingKeyUp);
            ActiveXHelper.RecomputeContainingControl = BitVector32.CreateMask(ActiveXHelper.IsMaskEdit);
            ActiveXHelper.logPixelsX = -1;
            ActiveXHelper.logPixelsY = -1;
            ActiveXHelper.REGMSG_MSG = SafeNativeMethods.RegisterWindowMessage(ApplicationShim.WindowMessagesVersion + "_subclassCheck");
        }

        public static int LogPixelsX
        {
            get
            {
                if (ActiveXHelper.logPixelsX == -1)
                {
                    IntPtr ptr = UnsafeNativeMethods.GetDC(NativeMethods.NullHandleRef);
                    if (ptr != IntPtr.Zero)
                    {
                        ActiveXHelper.logPixelsX = UnsafeNativeMethods.GetDeviceCaps(new HandleRef(null, ptr), 0x58);
                        UnsafeNativeMethods.ReleaseDC(NativeMethods.NullHandleRef, new HandleRef(null, ptr));
                    }
                }
                return ActiveXHelper.logPixelsX;
            }
        }

        public static int LogPixelsY
        {
            get
            {
                if (ActiveXHelper.logPixelsY == -1)
                {
                    IntPtr ptr = UnsafeNativeMethods.GetDC(NativeMethods.NullHandleRef);
                    if (ptr != IntPtr.Zero)
                    {
                        ActiveXHelper.logPixelsY = UnsafeNativeMethods.GetDeviceCaps(new HandleRef(null, ptr), 90);
                        UnsafeNativeMethods.ReleaseDC(NativeMethods.NullHandleRef, new HandleRef(null, ptr));
                    }
                }
                return ActiveXHelper.logPixelsY;
            }
        }

        internal static NativeMethods._RECT GetClipRect()
        {
            return new NativeMethods._RECT(new Rectangle(0, 0, 32000, 32000));
        }

        internal static int HM2Pix(int hm, int logP)
        {
            return (((logP * hm) + 1270) / 2540);
        }

        internal static int Pix2HM(int pix, int logP)
        {
            return (((0x9ec * pix) + (logP >> 1)) / logP);
        }

        internal static ISelectionService GetSelectionService(Control control)
        {
            ISite site = control.Site;
            if (site != null)
            {
                return site.GetService(typeof(ISelectionService)) as ISelectionService;
            }
            return null;
        }
    }
}
