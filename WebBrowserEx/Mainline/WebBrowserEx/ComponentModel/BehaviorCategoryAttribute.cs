//-----------------------------------------------------------------------
// <copyright file="BehaviorCategoryAttribute.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Specifies Behavior as the category in which to group the property or event when displayed in a Property Grid control set to Categorized mode.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.ComponentModel
{
    using System;

    /// <summary>
    /// Specifies Behavior as the category in which to group the property or event
    /// when displayed in a <see cref="T:System.Windows.Forms.PropertyGrid" /> control set to
    /// <see cref="System.Windows.Forms.PropertySort.Categorized" /> mode.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class BehaviorCategoryAttribute : ResourcesCategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorCategoryAttribute"/> class.
        /// </summary>
        public BehaviorCategoryAttribute()
            : base("BehaviorCategory")
        {
        }
    }
}