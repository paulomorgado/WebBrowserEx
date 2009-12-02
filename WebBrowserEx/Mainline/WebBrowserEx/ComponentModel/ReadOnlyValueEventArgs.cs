//-----------------------------------------------------------------------
// <copyright file="ReadOnlyValueEventArgs.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>Provides event data with a readonly value.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.ComponentModel
{
    using System;

    /// <summary>
    /// Provides event data with a readonly value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class ReadOnlyValueEventArgs<T> : global::System.EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyValueEventArgs&lt;T&gt;"/> class.
        /// </summary>
        public ReadOnlyValueEventArgs()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyValueEventArgs&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="value">The intial value.</param>
        public ReadOnlyValueEventArgs(T value)
            : base()
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public virtual T Value { get; protected set; }
    }
}
