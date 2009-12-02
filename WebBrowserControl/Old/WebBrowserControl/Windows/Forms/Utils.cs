using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pajocomo.Windows.Forms
{
    internal static class Utils
    {
        public static bool IsCriticalException(Exception ex)
        {
            return (ex is NullReferenceException)
                | (ex is StackOverflowException)
                | (ex is OutOfMemoryException)
                | (ex is ThreadAbortException)
                | (ex is ExecutionEngineException)
                | (ex is IndexOutOfRangeException)
                | (ex is AccessViolationException);
        }
    }
}
