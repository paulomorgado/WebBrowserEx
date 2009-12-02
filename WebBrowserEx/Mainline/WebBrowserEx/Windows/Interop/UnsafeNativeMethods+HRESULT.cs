//-----------------------------------------------------------------------
// <copyright file="UnsafeNativeMethods+HRESULT.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// HRESULT
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
    public static partial class UnsafeNativeMethods
    {
        public static class HRESULT
        {
            public const int S_OK = 0;
            public const int S_FALSE = 1;
            public const int FALSE = 0;
            public const int TRUE = 1;
            public const int E_NOTIMPL = unchecked((int)0x80004001L);
            public const int E_NOINTERFACE = unchecked((int)0x80004002L);
            public const int INET_E_DEFAULT_ACTION = unchecked((int)0x800C0011);
        }
    }
}
