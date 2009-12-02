//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+IEnumOLEVERB.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// IEnumOLEVERB
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System.Runtime.InteropServices;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
    public static partial class UnsafeNativeMethods
    {
        [ComImport]
        [Guid("00000104-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IEnumOLEVERB
        {
            [PreserveSig]
            int Next([MarshalAs(UnmanagedType.U4)] int celt, [Out] Interop.NativeMethods.OLEVERB rgelt, [Out, MarshalAs(UnmanagedType.LPArray)] int[] pceltFetched);

            [PreserveSig]
            int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);

            void Reset();

            void Clone(out IEnumOLEVERB ppenum);
        }
    }
}
