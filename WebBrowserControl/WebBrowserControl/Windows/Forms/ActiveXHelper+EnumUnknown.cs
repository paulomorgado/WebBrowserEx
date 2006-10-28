using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    internal partial class ActiveXHelper
    {
        internal class EnumUnknown : UnsafeNativeMethods.IEnumUnknown
        {
            private object[] arr;
            private int loc;
            private int size;

            private EnumUnknown()
            {
            }

            private EnumUnknown(object[] arr, int loc)
            {
                this.loc = loc;
            }

            public EnumUnknown(object[] arr)
            {
                this.arr = arr;
                this.loc = 0;
                this.size = (arr == null) ? 0 : arr.Length;
            }


            #region IEnumUnknown Members

            int UnsafeNativeMethods.IEnumUnknown.Next(int celt, IntPtr rgelt, IntPtr pceltFetched)
            {
                if (pceltFetched != IntPtr.Zero)
                {
                    Marshal.WriteInt32(pceltFetched, 0, 0);
                }

                if (celt < 0)
                {
                    return NativeMethods.HRESULT.E_INVALIDARG;
                }

                int el = 0;
                if (this.loc < this.size)
                {
                    while ((this.loc < this.size) && (el < celt))
                    {
                        if (this.arr[this.loc] != null)
                        {
                            Marshal.WriteIntPtr(rgelt, Marshal.GetIUnknownForObject(this.arr[this.loc]));
                            unsafe
                            {
                                rgelt = (IntPtr)(((long)rgelt) + sizeof(IntPtr));
                            }
                            el++;
                        }
                        this.loc++;
                    }
                }

                if (pceltFetched != IntPtr.Zero)
                {
                    Marshal.WriteInt32(pceltFetched, 0, el);
                }

                return (el != celt) ? NativeMethods.HRESULT.S_FALSE : NativeMethods.HRESULT.S_OK;
            }

            int UnsafeNativeMethods.IEnumUnknown.Skip(int celt)
            {
                this.loc += celt;

                return (this.loc >= this.size) ? NativeMethods.HRESULT.S_FALSE : NativeMethods.HRESULT.S_OK;
            }

            void UnsafeNativeMethods.IEnumUnknown.Reset()
            {
                this.loc = 0;
            }

            void UnsafeNativeMethods.IEnumUnknown.Clone(out UnsafeNativeMethods.IEnumUnknown ppenum)
            {
                ppenum = new ActiveXHelper.EnumUnknown(this.arr, this.loc);
            }

            #endregion
        }
    }
}
