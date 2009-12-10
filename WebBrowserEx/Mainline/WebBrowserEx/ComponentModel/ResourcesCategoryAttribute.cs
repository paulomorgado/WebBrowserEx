//-----------------------------------------------------------------------
// <copyright file="ResourcesCategoryAttribute.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Specifies, from a resource, the category in which to group the property or event when displayed in a Property Grid control set to Categorized mode.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.ComponentModel
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Specifies category in which to group the property or event
    /// when displayed in a <see cref="T:System.Windows.Forms.PropertyGrid" /> control set to
    /// <see cref="System.Windows.Forms.PropertySort.Categorized" /> mode.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    internal class ResourcesCategoryAttribute : global::System.ComponentModel.CategoryAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesCategoryAttribute"/> class.
        /// </summary>
        /// <param name="category">The name of the resource that has the name of the category.</param>
        public ResourcesCategoryAttribute(string category)
            : base(category)
        {
        }

        /// <summary>
        /// Looks up the localized name of the specified category.
        /// </summary>
        /// <param name="value">The identifer for the category to look up.</param>
        /// <returns>
        /// The localized name of the category, or null if a localized name does not exist.
        /// </returns>
        protected override string GetLocalizedString(string value)
        {
            return Properties.Resources.ResourceManager.GetString(value) ?? value;
        }
    }
}