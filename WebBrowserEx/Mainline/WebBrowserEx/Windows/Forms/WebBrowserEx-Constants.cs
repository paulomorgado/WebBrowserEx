//-----------------------------------------------------------------------
// <copyright file="WebBrowserEx-Constants.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// WebBrowserEx's constants.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.Forms
{
    /// <content>
    /// <see cref="T:WebBrowserEx"/>'s constants.
    /// </content>
    public partial class WebBrowserEx
    {
        /// <summary>
        /// <see cref="F:webBrowserState"/> bit mask for the value of the <see cref="P:No3DBorder"/> property.
        /// </summary>
        private static readonly int webBrowserStateNo3DBorder;

        /// <summary>
        /// <see cref="F:webBrowserState"/> bit mask for the value of the <see cref="P:No3DOuterBorder"/> property.
        /// </summary>
        private static readonly int webBrowserStateNo3DOuterBorder;

        /// <summary>
        /// <see cref="F:webBrowserState"/> bit mask for the value of the <see cref="P:RegisterAsBrowser"/> property.
        /// </summary>
        private static readonly int webBrowserStateRegisterAsBrowser;

        /// <summary>
        /// <see cref="F:webBrowserState"/> bit mask for the value of the <see cref="P:PrivacyImpacted"/> property.
        /// </summary>
        private static readonly int webBrowserStatePrivacyImpacted;

        /// <summary>
        /// <see cref="F:webBrowserState"/> bit mask for the value of the <see cref="P:Resizable"/> property.
        /// </summary>
        private static readonly int webBrowserStateResizable;

        /// <summary>
        /// Default value for the <see cref="P:WebBrowserControl.RegisterAsBrowser"/> property.
        /// </summary>
        private const bool RegisterAsBrowserDefaultValue = false;

        /// <summary>
        /// Default value for the <see cref="P:No3DOuterBorder"/> property.
        /// </summary>
        private const bool No3DOuterBorderDefaultValue = false;

        /// <summary>
        /// Default value for the <see cref="P:No3DOuterBorder"/> property.
        /// </summary>
        private const bool No3DBorderDefaultValue = false;

        /// <summary>
        /// Default value for the <see cref="P:WebBrowserControl.UserAgent"/> property.
        /// </summary>
        private const string UserAgentDefaultValue = null;

        /// <summary>
        /// <see cref="T:System.Reflection.FieldInfo"/> for the <see cref="F:System.Windows.Forms.WebBrowser.encryptionLevel"/> private field.
        /// </summary>
        private static readonly System.Reflection.FieldInfo encryptionLevelFieldInfo;

        /// <summary>
        /// <see cref="T:System.Reflection.PropertyInfo"/> for the <see cref="P:System.Windows.Forms.WebBrowser.GoBackInternal"/> internal property.
        /// </summary>
        private static readonly System.Reflection.PropertyInfo canGoBackInternalPropertyInfo;

        /// <summary>
        /// <see cref="T:System.Reflection.PropertyInfo"/> for the <see cref="P:System.Windows.Forms.WebBrowser.GoForwardInternal"/> internal property.
        /// </summary>
        private static readonly System.Reflection.PropertyInfo canGoForwardInternalPropertyInfo;
    }
}
