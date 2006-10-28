using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Defines the coordinates of the upper-left and lower-right corners of a rectangle.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class _RECT
        {
            /// <summary>
            /// Specifies the x-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int left;

            /// <summary>
            /// Specifies the y-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int top;

            /// <summary>
            /// Specifies the x-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int right;

            /// <summary>
            /// Specifies the y-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int bottom;

            /// <summary>
            /// Creates a new <see cref="_RECT"/> instance given the <paramref name="x"/>, <paramref name="y"/>, <paramref name="width"/> and <paramref name="height"/>.
            /// </summary>
            /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
            /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
            /// <param name="width">The width of the rectangle.</param>
            /// <param name="height">The height of the rectangle.</param>
            /// <returns></returns>
            public static NativeMethods._RECT FromXYWH(int x, int y, int width, int height)
            {
                return new NativeMethods._RECT(x, y, x + width, y + height);
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="COMRECT"/> class.
            /// </summary>
            public _RECT()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="_RECT"/> class given a <see cref="TActiveX:System.Drawing.Rectangle"/> instance.
            /// </summary>
            /// <param name="r">A <see cref="TActiveX:System.Drawing.Rectangle"/>.</param>
            public _RECT(System.Drawing.Rectangle r)
            {
                this.left = r.X;
                this.top = r.Y;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="COMRECT"/> class given the <paramref name="left"/>, <paramref name="top"/>, <paramref name="right"/> and <paramref name="bottom"/>.
            /// </summary>
            /// <param name="left">The x-coordinate of the upper-left corner of the rectangle.</param>
            /// <param name="top">The y-coordinate of upper-left corner of the rectangle.</param>
            /// <param name="right">The x-coordinate of the lower-right corner of the rectangle.</param>
            /// <param name="bottom">The y-coordinate of the lower-right corner of the rectangle.</param>
            public _RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            /// <summary>
            /// Returns a <see cref="TActiveX:System.String"></see> that represents the current <see cref="TActiveX:System.Object"></see>.
            /// </summary>
            /// <returns>
            /// A <see cref="TActiveX:System.String"></see> that represents the current <see cref="TActiveX:System.Object"></see>.
            /// </returns>
            public override string ToString()
            {
                return string.Concat(new object[] { "Left = ", this.left, " Top ", this.top, " Right = ", this.right, " Bottom = ", this.bottom });
            }
        }
    }
}
