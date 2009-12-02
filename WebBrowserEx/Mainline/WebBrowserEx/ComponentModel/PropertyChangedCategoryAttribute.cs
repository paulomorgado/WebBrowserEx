//-----------------------------------------------------------------------
// <copyright file="PropertyChangedCategoryAttribute.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>Specifies Property Changed as the category in which to group the property or event when displayed in a Property Grid control set to Categorized mode.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.ComponentModel
{
    using System;

    /// <summary>
    /// Specifies PropertyChanged as the category in which to group the property or event
    /// when displayed in a <see cref="T:System.Windows.Forms.PropertyGrid" /> control set to
    /// <see cref="System.Windows.Forms.PropertySort.Categorized" /> mode.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class PropertyChangedCategoryAttribute : ResourcesCategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyChangedCategoryAttribute"/> class.
        /// </summary>
        public PropertyChangedCategoryAttribute()
            : base("PropertyChangedCategory")
        {
        }
    }
}