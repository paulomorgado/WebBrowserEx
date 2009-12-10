//-----------------------------------------------------------------------
// <copyright file="ResourcesDescriptionAttribute.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// Specifies, from a resource, the description when displayed in a Property Grid.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.ComponentModel
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Specifies a description for a property or event.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    internal class ResourcesDescriptionAttribute : global::System.ComponentModel.DescriptionAttribute
    {
        /// <summary>
        /// Indicates wheather the <see cref="P:DesciptionValue"/> has already been replaced.
        /// </summary>
        private bool replaced;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesDescriptionAttribute"/> class.
        /// </summary>
        /// <param name="description">The name of the resource that has the description text.</param>
        public ResourcesDescriptionAttribute(string description)
            : base(description)
        {
        }

        /// <summary>
        /// Gets the description stored in this attribute.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The description stored in this attribute.
        /// </returns>
        public override string Description
        {
            get
            {
                if (!this.replaced)
                {
                    this.replaced = true;
                    this.DescriptionValue = Properties.Resources.ResourceManager.GetString(base.Description) ?? base.Description;
                }

                return this.DescriptionValue;
            }
        }
    }
}
