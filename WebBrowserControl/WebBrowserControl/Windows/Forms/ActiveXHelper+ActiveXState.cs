using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    internal partial class ActiveXHelper
    {
        internal enum ActiveXState : int
        {
            Passive = 0,
            Loaded = 1,
            Running = 2,
            InPlaceActive = 4,
            UIActive = 8
        }
    }
}
