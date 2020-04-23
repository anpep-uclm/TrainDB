using System;
using System.Runtime.InteropServices;

namespace TrainDB {
    /// <summary>
    ///     Utility methods for native control theming
    /// </summary>
    internal static class NativeMethods {
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        internal static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);
    }
}
