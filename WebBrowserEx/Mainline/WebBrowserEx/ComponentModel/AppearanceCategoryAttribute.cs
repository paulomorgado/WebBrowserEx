//-----------------------------------------------------------------------
// <copyright file="AppearanceCategoryAttribute.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Specifies Appearance as the category in which to group the property or event when displayed in a Property Grid control set to Categorized mode.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.ComponentModel
{
    using System;

    /// <summary>
    /// Specifies Appearance as the category in which to group the property or event
    /// when displayed in a <see cref="T:System.Windows.Forms.PropertyGrid" /> control set to
    /// <see cref="System.Windows.Forms.PropertySort.Categorized" /> mode.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class AppearanceCategoryAttribute : ResourcesCategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppearanceCategoryAttribute"/> class.
        /// </summary>
        public AppearanceCategoryAttribute()
            : base("AppearanceCategory")
        {
        }
    }
}