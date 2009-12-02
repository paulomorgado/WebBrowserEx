//-----------------------------------------------------------------------
// <copyright file="SafeNativeMethods+Urlmon.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Urlmon.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Interop
{
    using System.Runtime.InteropServices;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Interop Code")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented", Justification = "Interop Code")]
    public static partial class SafeNativeMethods
    {
        public static class Urlmon
        {
            public const int URLMON_OPTION_USERAGENT = 0x10000001;
            public const int URLMON_OPTION_USERAGENT_REFRESH = 0x10000002;
            public const int URLMON_OPTION_URL_ENCODING = 0x10000004;
            public const int URLMON_OPTION_USE_BINDSTRINGCREDS = 0x10000008;

            [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
            public static extern int UrlMkGetSessionOption(
                int dwOption,
                System.Text.StringBuilder pBuffer,
                int dwBufferLength,
                ref int pdwBufferLength,
                int dwReserved);

            [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
            public static extern int UrlMkSetSessionOption(
                int dwOption,
                string pBuffer,
                int dwBufferLength,
                int dwReserved);
        }
    }
}
