//-----------------------------------------------------------------------
// <copyright file="EventHandlerListExtensions.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>EventHandlerList extensions.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.ComponentModel
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// <see cref="T:EventHandlerList"/> extensions.
    /// </summary>
    public static class EventHandlerListExtensions
    {
        /*
        /// <summary>
        /// Fires the event keyed by <paramref name="eventKey"/>.
        /// </summary>
        /// <param name="self">The event handler list.</param>
        /// <param name="eventKey">The event key.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void Fire<T>(this EventHandlerList self, object eventType, T e) where T : EventArgs
        {
            EventHandler<T> events = self[eventType] as EventHandler<T>;

            if (events != null)
            {
                events(this, e);
            }
        }
        */

        /// <summary>
        /// Fires the event keyed by <paramref name="eventKey"/>.
        /// </summary>
        /// <param name="self">The event handler list.</param>
        /// <param name="eventKey">The event key.</param>
        /// <param name="source">The event source.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public static void Fire(this EventHandlerList self, object eventKey, object source, EventArgs e)
        {
            Delegate events = self[eventKey];

            if (events != null)
            {
                events.DynamicInvoke(source, e);
            }
        }
    }
}
